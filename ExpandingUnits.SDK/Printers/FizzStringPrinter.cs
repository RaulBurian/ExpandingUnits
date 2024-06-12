// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzStringPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The fizz printer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Factories;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The fizz string printer.
/// </summary>
public class FizzStringPrinter : IStringPrinter
{
    /// <summary>
    /// The print.
    /// </summary>
    public void Print(StringBuilder stringBuilder)
    {
        var myFizzStringReturnerFactory = new FizzStringReturnerFactory();
        IStringStringReturner myFizzStringReturner = myFizzStringReturnerFactory.CreateStringStringReturner();
        stringBuilder.Append(myFizzStringReturner.GetReturnString());
    }
}
