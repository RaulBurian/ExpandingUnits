// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoFizzNoBuzzStrategyFactory.cs" company="SeriousCompany">
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
/// The no fizz no buzz strategy factory.
/// </summary>
public class NoFizzNoBuzzStrategyFactory : IIsEvenlyDivisibleStrategyFactory
{
    /// <summary>
    /// The create is evenly divisible strategy.
    /// </summary>
    /// <returns>
    /// The <see cref="IIsEvenlyDivisibleStrategy"/>.
    /// </returns>
    public IIsEvenlyDivisibleStrategy CreateIsEvenlyDivisibleStrategy()
    {
            var myNoFizzNoBuzzStrategy = new NoFizzNoBuzzStrategy();
            return myNoFizzNoBuzzStrategy;
        }
}