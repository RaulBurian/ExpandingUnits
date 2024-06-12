// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIntegerPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The IntegerPrinter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace ExpandingUnits.SDK.Interfaces;

/// <summary>
/// The IntegerPrinter interface.
/// </summary>
public interface IIntegerPrinter
{
    /// <summary>
    /// Prints an integer.
    /// </summary>
    /// <param name="i">
    /// The integer to print.
    /// </param>
    void PrintInteger(int i, StringBuilder stringBuilder);
}
