// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStringPrinterFactory.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the BuzzStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ExpandingUnits.SDK.Interfaces;
using ExpandingUnits.SDK.StringReturners;

namespace ExpandingUnits.SDK.Factories;

/// <summary>
/// The integer integer string returner factory.
/// </summary>
public class IntegerIntegerStringReturnerFactory : IIntegerStringReturnerFactory 
{
    /// <summary>
    /// The create integer string returner.
    /// </summary>
    /// <returns>
    /// The <see cref="IIntegerStringReturner"/>.
    /// </returns>
    public IIntegerStringReturner CreateIntegerStringReturner()
    {
            var myIntegerIntegerStringReturner = new IntegerIntegerStringReturner();
            return myIntegerIntegerStringReturner;
        }
}