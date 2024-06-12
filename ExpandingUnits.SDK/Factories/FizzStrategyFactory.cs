// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzStrategyFactory.cs" company="SeriousCompany">
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
/// The fizz strategy factory.
/// </summary>
public class FizzStrategyFactory : IIsEvenlyDivisibleStrategyFactory
{
    /// <summary>
    /// The create is evenly divisible strategy.
    /// </summary>
    /// <returns>
    /// The <see cref="IIsEvenlyDivisibleStrategy"/>.
    /// </returns>
    public IIsEvenlyDivisibleStrategy CreateIsEvenlyDivisibleStrategy()
    {
            var myFizzStrategy = new FizzStrategy();
            return myFizzStrategy;
        }
}