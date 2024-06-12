// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewLineStringPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the IntegerIntegerStringReturner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Factories;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The new line string printer.
/// </summary>
public class NewLineStringPrinter : IStringPrinter
{
    /// <summary>
    /// The print.
    /// </summary>
    public void Print(StringBuilder stringBuilder)
    {
        IStringStringReturnerFactory myNewLineStringReturnerFactory = new NewLineStringReturnerFactory();
        var myNewLineStringReturner = myNewLineStringReturnerFactory.CreateStringStringReturner();
        var myNewLineString = myNewLineStringReturner.GetReturnString();
        stringBuilder.Append(myNewLineString);
    }
}
