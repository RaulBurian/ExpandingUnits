// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzStringReturnerFactory.cs" company="SeriousCompany">
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
/// The fizz string returner factory.
/// </summary>
public class FizzStringReturnerFactory : IStringStringReturnerFactory
{
    /// <summary>
    /// The create string string returner.
    /// </summary>
    /// <returns>
    /// The <see cref="IStringStringReturner"/>.
    /// </returns>
    public IStringStringReturner CreateStringStringReturner()
    {
            var myFizzStringReturner = new FizzStringReturner();
            return myFizzStringReturner;
        }
}