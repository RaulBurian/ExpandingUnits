// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzBuzz.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the BuzzStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Factories;

namespace ExpandingUnits.SDK;

public class FizzBuzz
{
    // public string Fizzbuzz(int n)
    // {
    //     var myLoopComponentFactory = new LoopComponentFactory();
    //     var myLoopInitializer = myLoopComponentFactory.CreateLoopInitializer();
    //     var myLoopCondition = myLoopComponentFactory.CreateLoopCondition();
    //     var myLoopStep = myLoopComponentFactory.CreateLoopStep();
    //
    //     var myFizzStrategyFactory = new FizzStrategyFactory();
    //     var myFizzStrategy = myFizzStrategyFactory.CreateIsEvenlyDivisibleStrategy();
    //     var myFizzStringPrinterFactory = new FizzStringPrinterFactory();
    //     var myFizzStringPrinter = myFizzStringPrinterFactory.CreateStringPrinter();
    //
    //     var myBuzzStrategyFactory = new BuzzStrategyFactory();
    //     var myBuzzStrategy = myBuzzStrategyFactory.CreateIsEvenlyDivisibleStrategy();
    //     var myBuzzStringPrinterFactory = new BuzzStringPrinterFactory();
    //     var myBuzzStringPrinter = myBuzzStringPrinterFactory.CreateStringPrinter();
    //
    //     var myNoFizzNoBuzzStrategyFactory = new NoFizzNoBuzzStrategyFactory();
    //     var myNoFizzNoBuzzStrategy = myNoFizzNoBuzzStrategyFactory.CreateIsEvenlyDivisibleStrategy();
    //     var myIntIntegerPrinterFactory = new IntIntegerPrinterFactory();
    //     var myIntIntegerPrinter = myIntIntegerPrinterFactory.CreatePrinter();
    //
    //     var myNewLineStringPrinterFactory = new NewLineStringPrinterFactory();
    //     var myNewLinePrinter = myNewLineStringPrinterFactory.CreateStringPrinter();
    //
    //     var stringBuilder = new StringBuilder();
    //
    //     for (var i = myLoopInitializer.GetLoopInitializationPoint();
    //          myLoopCondition.EvaluateLoop(i, n);
    //          i = myLoopStep.StepLoop(i))
    //     {
    //         if (myFizzStrategy.IsEvenlyDivisible(i))
    //         {
    //             myFizzStringPrinter.Print(stringBuilder);
    //         }
    //
    //         if (myBuzzStrategy.IsEvenlyDivisible(i))
    //         {
    //             myBuzzStringPrinter.Print(stringBuilder);
    //         }
    //
    //         if (myNoFizzNoBuzzStrategy.IsEvenlyDivisible(i))
    //         {
    //             myIntIntegerPrinter.PrintInteger(i, stringBuilder);
    //         }
    //
    //         myNewLinePrinter.Print(stringBuilder);
    //     }
    //
    //     return stringBuilder.ToString();
    // }

    #region Hidden
    public string Fizzbuzz(int n)
    {
        var stringBuilder = new StringBuilder();
    
        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0)
            {
                stringBuilder.Append("Fizz");
            }
    
            if (i % 5 == 0)
            {
                stringBuilder.Append("Buzz");
            }
    
            if (i % 3 != 0 && i % 5 != 0)
            {
                stringBuilder.Append(i);
            }
    
            stringBuilder.Append(' ');
        }
    
        return stringBuilder.ToString();
    }
    #endregion
}
