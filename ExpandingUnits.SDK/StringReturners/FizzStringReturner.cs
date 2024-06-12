// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FizzStringReturner.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The Fizz string returner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.StringReturners;

/// <summary>
/// The Fizz string returner.
/// </summary>
public class FizzStringReturner : IStringStringReturner
{
    /// <summary>
    /// The get return string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public string GetReturnString()
    {
            var myStringBuilder = new StringBuilder("Fizz");
            var myString = myStringBuilder.ToString();
            return myString;
        }
}