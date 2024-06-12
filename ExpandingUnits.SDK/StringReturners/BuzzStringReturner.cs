// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzStringReturner.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The buzz string returner.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.StringReturners;

/// <summary>
/// The buzz string returner.
/// </summary>
public class BuzzStringReturner : IStringStringReturner
{
    /// <summary>
    /// The get return string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public string GetReturnString()
    {
            var myStringBuilder = new StringBuilder("Buzz");
            var myString = myStringBuilder.ToString();
            return myString;
        }
}