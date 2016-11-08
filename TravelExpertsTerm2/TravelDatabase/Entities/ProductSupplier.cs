// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System.Collections.Generic;
using FluentValidation;
using JetBrains.Annotations;

namespace TravelDatabase
{
    [Devin]
    public class ProductSupplier : IValidatable
    {
        public int ProductSupplierId { get; set; }

        [CanBeNull]
        public Product Product { get; [NotNull] set; }

        [CanBeNull]
        public Supplier Supplier { get; [NotNull] set; }

        [NotNull]
        public string FullName => $"{Product?.Name} | {Supplier?.Name}";

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
            _validator ?? (_validator = new ProductSupplierValidator());

        // Validation rules for type <T> may be specified in the constructor of a class inheriting
        // from FluentValidator's AbstractValidator<T>. This is how the fluent API is exposed.
        private sealed class ProductSupplierValidator : AbstractValidator<ProductSupplier>
        {
            private static IValidator<Product> ProductValidator
                => (IValidator<Product>)new Product().GetValidator();

            private static IValidator<Supplier> SupplierValidator
                => (IValidator<Supplier>)new Supplier().GetValidator();

            public ProductSupplierValidator()
            {
                // I sometimes use int.MinValue to denote invalid IDs, so I check for that
                RuleFor(obj => obj.ProductSupplierId)
                    .GreaterThan(int.MinValue)
                    .WithMessage($"{nameof(ProductSupplierId)} cannot be {int.MinValue}.");

                RuleFor(obj => obj.Product)
                    .NotNull()
                    .WithMessage($"{nameof(Product)} is required.");
                RuleFor(obj => obj.Product).SetValidator(ProductValidator);

                RuleFor(obj => obj.Supplier)
                    .NotNull()
                    .WithMessage($"{nameof(Supplier)} is required.");
                RuleFor(obj => obj.Supplier).SetValidator(SupplierValidator);
            }
        }

        #endregion
    }
}