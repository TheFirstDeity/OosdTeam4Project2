// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using FluentValidation;
using JetBrains.Annotations;

namespace TravelDatabase
{
    public class Supplier : IValidatable
    {
        public int SupplierId { get; set; }

        [CanBeNull]
        public string Name { get; [NotNull] set; }
        //public int SupplierId { get; set; }
        //public string Name { get; set; }

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
            _validator ?? (_validator = new SupplierValidator());

        // Validation rules for type <T> may be specified in the constructor of a class inheriting
        // from FluentValidator's AbstractValidator<T>. This is how the fluent API is exposed.
        [Devin]
        private sealed class SupplierValidator : AbstractValidator<Supplier>
        {
            public SupplierValidator()
            {
                // I sometimes use int.MinValue to denote invalid IDs, so I check for that
                RuleFor(obj => obj.SupplierId)
                    .GreaterThan(int.MinValue)
                    .WithMessage($"{nameof(SupplierId)} cannot be {int.MinValue}.");

                RuleFor(obj => obj.Name)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage($"{nameof(Supplier)}'s name is required.");
            }
        }

        #endregion
    }
}
