// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStringReturnerFactory.cs" company="SeriousCompany">
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
/// The buzz string returner factory.
/// </summary>
public class BuzzStringReturnerFactory : IStringStringReturnerFactory
{
    /// <summary>
    /// The create string string returner.
    /// </summary>
    /// <returns>
    /// The <see cref="IStringStringReturner"/>.
    /// </returns>
    public IStringStringReturner CreateStringStringReturner()
    {
            var myBuzzStringReturner = new BuzzStringReturner();
            return myBuzzStringReturner;
        }
}