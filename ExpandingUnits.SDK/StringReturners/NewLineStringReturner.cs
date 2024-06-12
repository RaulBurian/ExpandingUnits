// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewLineStringReturner.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   Defines the NewLineStringReturner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.Interfaces;

namespace ExpandingUnits.SDK.StringReturners;

/// <summary>
/// The new line string returner.
/// </summary>
public class NewLineStringReturner : IStringStringReturner
{
    /// <summary>
    /// The get return string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public string GetReturnString()
    {
        var systemDefaultNewLineString = " ";
        var myStringBuilder = new StringBuilder(systemDefaultNewLineString);
        var myString = myStringBuilder.ToString();
        return myString;
    }
}
