// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIntegerPrinterFactory.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The IntegerPrinterFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ExpandingUnits.SDK.Interfaces;

/// <summary>
/// The IntegerPrinterFactory interface.
/// </summary>
public interface IIntegerPrinterFactory
{
    /// <summary>
    /// Creates the printer.
    /// </summary>
    /// <returns>
    /// The <see cref="IIntegerPrinter"/>.
    /// </returns>
    IIntegerPrinter CreatePrinter();
}