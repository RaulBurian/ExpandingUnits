// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStringPrinterFactory.cs" company="SeriousCompany">
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
/// The buzz string printer factory.
/// </summary>
public class BuzzStringPrinterFactory : IStringPrinterFactory
{
    /// <summary>
    /// The create string printer.
    /// </summary>
    /// <returns>
    /// The <see cref="IStringPrinter"/>.
    /// </returns>
    public IStringPrinter CreateStringPrinter()
    {
        var myBuzzStringPrinter = new BuzzStringPrinter();
        return myBuzzStringPrinter;
    }
}