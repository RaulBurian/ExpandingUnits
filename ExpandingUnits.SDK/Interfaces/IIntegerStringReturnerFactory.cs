// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIntegerStringReturnerFactory.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The IntegerStringReturnerFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ExpandingUnits.SDK.Interfaces;

/// <summary>
/// The IntegerStringReturnerFactory interface.
/// </summary>
public interface IIntegerStringReturnerFactory
{
    /// <summary>
    /// The create integer string returner.
    /// </summary>
    /// <returns>
    /// The <see cref="IIntegerStringReturner"/>.
    /// </returns>
    IIntegerStringReturner CreateIntegerStringReturner();
}