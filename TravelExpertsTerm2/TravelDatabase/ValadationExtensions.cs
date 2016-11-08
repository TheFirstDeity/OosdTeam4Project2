// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using JetBrains.Annotations;

namespace TravelDatabase
{
    [Devin]
    public static class ValadationExtensions
    {
        static ValadationExtensions()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        /// <summary>
        /// Validate this object using its default <see cref="IValidator"/>
        /// </summary>
        /// <returns><see cref="ValidationResult"/></returns>
        [Pure]
        [NotNull]
        public static ValidationResult ValidateSelf(this IValidatable obj)
        {
            return obj.GetValidator().Validate(obj);
        }

        /// <summary>
        /// Formats <see cref="ValidationResult.Errors"/> into a report. Each 
        /// message is separated by a line break. A header can optionally be included.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="header">Optional header text</param>
        /// <returns>Formatted <see cref="string"/></returns>
        [Pure]
        [NotNull]
        public static string FormattedErrorMessageList(this ValidationResult obj, string header = null)
        {
            if (header != null) header += Environment.NewLine + Environment.NewLine;
            return (header ?? string.Empty) +
                   string.Join(Environment.NewLine, obj.Errors.Select(err => "- " + err.ErrorMessage));
        }
    }
}
