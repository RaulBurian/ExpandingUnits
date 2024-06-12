// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStrategyFactory.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the BuzzStrategyFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ExpandingUnits.SDK.Interfaces;
using ExpandingUnits.SDK.Strategies;

namespace ExpandingUnits.SDK.Factories;

/// <summary>
/// The buzz strategy factory.
/// </summary>
public class BuzzStrategyFactory : IIsEvenlyDivisibleStrategyFactory
{
    /// <summary>
    /// The create is evenly divisible strategy.
    /// </summary>
    /// <returns>
    /// The <see cref="IIsEvenlyDivisibleStrategy"/>.
    /// </returns>
    public IIsEvenlyDivisibleStrategy CreateIsEvenlyDivisibleStrategy()
    {
        var myBuzzStrategy = new BuzzStrategy();
        return myBuzzStrategy;
    }
}