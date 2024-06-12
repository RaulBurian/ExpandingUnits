// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStringPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The StringPrinter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace ExpandingUnits.SDK.Interfaces;

/// <summary>
/// The StringPrinter interface.
/// </summary>
public interface IStringPrinter
{
    /// <summary>
    /// Prints the string.
    /// </summary>
    void Print(StringBuilder stringBuilder);
}
