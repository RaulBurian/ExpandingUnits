// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerIntegerPrinter.cs" company="SeriousCompany">
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
/// The integer integer printer.
/// </summary>
public class IntegerIntegerPrinter : IIntegerPrinter
{
    /// <summary>
    /// The print integer.
    /// </summary>
    /// <param name="i">
    /// The i.
    /// </param>
    public void PrintInteger(int i, StringBuilder stringBuilder)
    {
        var myIntegerIntegerStringReturnerFactory = new IntegerIntegerStringReturnerFactory();
        IIntegerStringReturner myIntegerStringReturner =
            myIntegerIntegerStringReturnerFactory.CreateIntegerStringReturner();
        var myIntegerString = myIntegerStringReturner.GetIntegerReturnString(i);
        stringBuilder.Append(myIntegerString);
    }
}
