// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStringPrinter.cs" company="">
//
// </copyright>
// <summary>
//   The buzz string printer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Factories;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The buzz string printer.
/// </summary>
public class BuzzStringPrinter : IStringPrinter
{
    /// <summary>
    /// The print.
    /// </summary>
    public void Print(StringBuilder stringBuilder)
    {
        IStringStringReturnerFactory myBuzzStringReturnerFactory = new BuzzStringReturnerFactory();
        IStringStringReturner myBuzzStringReturner = myBuzzStringReturnerFactory.CreateStringStringReturner();
        stringBuilder.Append(myBuzzStringReturner.GetReturnString());
    }
}
