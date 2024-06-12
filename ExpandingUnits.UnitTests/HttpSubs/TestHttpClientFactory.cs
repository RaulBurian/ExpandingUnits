using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ExpandingUnits.UnitTests.HttpSubs;

public class TestHttpClientFactory : IHttpClientFactory
{
    private readonly IDictionary<string, HttpServerInfo> _servers;

    public TestHttpClientFactory(IDictionary<string, HttpServerInfo> servers)
    {
        _servers = servers;
    }

    public HttpClient CreateClient(string name)
    {
        return new HttpClient(_servers[name].Server) { BaseAddress = new Uri(_servers[name].BaseAddress) };
    }

    public record HttpServerInfo(HttpServer Server, string BaseAddress = "https://domain.com");
}

public class HttpServer : HttpMessageHandler
{
    public Queue<RequestWithTask> RequestsQueue { get; } = new();

    public Queue<Response> ResponsesQueue { get; } = new();

    public Queue<RequestWithTask> ExecutedRequestsQueue { get; } = new();

    public async Task WaitUntilRequestQueueHasCount(int count, TimeSpan timeout)
    {
        var cts = new CancellationTokenSource(timeout);
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(50));

        try
        {
            while (await timer.WaitForNextTickAsync(cts.Token))
            {
                if (RequestsQueue.Count == count)
                {
                    await cts.CancelAsync();
                }
            }
        }
        catch (TaskCanceledException)
        {
        }
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();

        RequestsQueue.Enqueue(new RequestWithTask(request, taskCompletionSource));

        ConsumeRequests();

        return taskCompletionSource.Task;
    }

    public void ConsumeRequests()
    {
        while (RequestsQueue.Count != 0 && ResponsesQueue.Count != 0)
        {
            var response = ResponsesQueue.Dequeue();
            var request = RequestsQueue.Dequeue();

            ExecutedRequestsQueue.Enqueue(request);

            if (response.Exception != null)
            {
                request.TaskCompletionSource.SetException(response.Exception);
            }
            else
            {
                response.HttpResponse.RequestMessage = request.HttpRequest;
                request.TaskCompletionSource.SetResult(response.HttpResponse);
            }
        }
    }

    public record RequestWithTask(HttpRequestMessage HttpRequest, TaskCompletionSource<HttpResponseMessage> TaskCompletionSource);

    public class Response
    {
        public HttpResponseMessage HttpResponse { get; set; }

        public Exception Exception { get; set; }

        public static Response Ok<T>(T data = null) where T : class
        {
            var mediaTypeHeaderValue = new MediaTypeHeaderValue("application/json");

            return new Response { HttpResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = JsonContent.Create(data, mediaTypeHeaderValue) } };
        }

        public static Response Ok(string responseBody)
        {
            var mediaTypeHeaderValue = new MediaTypeHeaderValue("application/json");

            return new Response { HttpResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(responseBody, mediaTypeHeaderValue) } };
        }

        public static Response BadRequest(string responseBody)
        {
            return new Response { HttpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest) };
        }

        public static Response InternalServerError()
        {
            return new Response { HttpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError) };
        }

        public static Response BadRequest()
        {
            return new Response { HttpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest) };
        }

        public static Response WithException(Exception exception)
        {
            return new Response { Exception = exception };
        }

        public static Response WithOperationCanceledException()
        {
            return new Response { Exception = new OperationCanceledException() };
        }
    }
}
