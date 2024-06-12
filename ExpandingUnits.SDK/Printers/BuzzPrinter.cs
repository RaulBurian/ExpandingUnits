// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuzzPrinter.cs" company="SeriousCompany">
// Copyright 2013 Serious Company
// </copyright>
// <summary>
//   The buzz printer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using ExpandingUnits.SDK.StringReturners;

namespace ExpandingUnits.SDK.Printers;

/// <summary>
/// The buzz printer.
/// </summary>
public class BuzzPrinter
{
    /// <summary>
    /// The print buzz.
    /// </summary>
    public void PrintBuzz(StringBuilder stringBuilder)
    {
        var myBuzzStringReturner = new BuzzStringReturner();
        stringBuilder.Append(myBuzzStringReturner.GetReturnString());
    }
}