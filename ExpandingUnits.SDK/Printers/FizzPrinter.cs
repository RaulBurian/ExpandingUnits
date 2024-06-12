// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The fizz printer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.StringReturners;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The fizz printer.
/// </summary>
public class FizzPrinter
{
    /// <summary>
    /// The print fizz.
    /// </summary>
    public void PrintFizz(StringBuilder stringBuilder)
    {
        var myFizzStringReturner = new FizzStringReturner();
        stringBuilder.Append(myFizzStringReturner.GetReturnString());
    }
}
