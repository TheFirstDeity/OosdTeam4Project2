// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using FluentValidation;
using JetBrains.Annotations;

namespace TravelDatabase
{
    [Devin]
    public interface IValidatable
    {
        /// <summary>
        /// Get an <see cref="IValidator"/> for this object.
        /// </summary>
        /// <returns>An implementation of <see cref="IValidator"/> that can be used to validate this object.</returns>
        IValidator GetValidator();
    }
}
