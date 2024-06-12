// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntIntegerPrinterFactory.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the BuzzStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ExpandingUnits.SDK.Interfaces;
using ExpandingUnits.SDK.Printers;

namespace ExpandingUnits.SDK.Factories;

/// <summary>
/// The integer integer printer factory.
/// </summary>
public class IntIntegerPrinterFactory : IIntegerPrinterFactory
{
    /// <summary>
    /// The create printer.
    /// </summary>
    /// <returns>
    /// The <see cref="IIntegerPrinter"/>.
    /// </returns>
    public IIntegerPrinter CreatePrinter()
    {
            var myIntIntegerPrinter = new IntegerIntegerPrinter();
            return myIntIntegerPrinter;
        }
}