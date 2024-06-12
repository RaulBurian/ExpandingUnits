// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewLinePrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the IntegerIntegerStringReturner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.StringReturners;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The new line printer.
/// </summary>
public class NewLinePrinter
{
    /// <summary>
    /// The print new line.
    /// </summary>
    public void PrintNewLine(StringBuilder stringBuilder)
    {
        var myNewLineStringReturner = new NewLineStringReturner();
        var myNewLineString = myNewLineStringReturner.GetReturnString();
        stringBuilder.Append(myNewLineString);
    }
}
