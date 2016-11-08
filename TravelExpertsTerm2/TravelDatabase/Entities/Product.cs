// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using FluentValidation;
using JetBrains.Annotations;

namespace TravelDatabase
{
    /// <remarks>
    /// This class is only used in unit tests. 
    /// It should be replaced by a dummy DB table that's never modified,
    /// and this class shold go away.
    /// </remarks>>
    [Devin]
    public class Product : IValidatable
    {
        public int ProductId { get; set; }

        [CanBeNull]
        public string Name { get; [NotNull] set; }

        public override string ToString()
        {
            return Name;
        }

        #region IValidatable

        // This is static so that it's only ever initialized once, which saves a small amount
        // of system resources. One disadvantage is that it's technically possible to change/add
        // validation rules at runtime by casting the IValidator as its concrete type.
        private static IValidator _validator;

        // This is called "lazy initialization". If _validator is null, it will be initialized to a
        // new instance. After that, the same instance will be returned every time this method is called.
        [Pure]
        [NotNull]
        [Devin]
        public IValidator GetValidator() =>
            _validator ?? (_validator = new ProductValidator());

        // Validation rules for type <T> may be specified in the constructor of a class inheriting
        // from FluentValidator's AbstractValidator<T>. This is how the fluent API is exposed.
        private sealed class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                // I sometimes use int.MinValue to denote invalid IDs, so I check for that
                RuleFor(obj => obj.ProductId)
                    .GreaterThan(int.MinValue)
                    .WithMessage($"{nameof(ProductId)} cannot be {int.MinValue}.");

                RuleFor(obj => obj.Name)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage($"{nameof(Product)}'s name is required.");
            }
        }

        #endregion
    }
}