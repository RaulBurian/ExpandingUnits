// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the IntegerIntegerStringReturner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Interfaces;
using ExpandingUnits.SDK.StringReturners;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The integer printer.
/// </summary>
public class IntPrinter
{
    /// <summary>
    /// The print integer.
    /// </summary>
    /// <param name="i">
    /// The i.
    /// </param>
    public void PrintInteger(int i, StringBuilder stringBuilder)
    {
        IIntegerStringReturner myIntegerIntegerStringReturner = new IntegerIntegerStringReturner();
        var myIntegerString = myIntegerIntegerStringReturner.GetIntegerReturnString(i);
        stringBuilder.Append(myIntegerString);
    }
}
