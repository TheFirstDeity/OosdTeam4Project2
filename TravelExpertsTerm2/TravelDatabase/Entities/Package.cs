// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using FluentValidation;

namespace TravelDatabase
{
    [Devin]
    [PublicAPI]
    public class Package : IValidatable
    {
        public int PackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal BasePrice { get; set; }
        public decimal AgencyCommission { get; set; }

        [CanBeNull]
        public string Name { get; [NotNull] set; }

        [CanBeNull]
        public string Description { get; [NotNull] set; }

        [NotNull]
        public List<ProductSupplier> ProductSuppliers { get; } = new List<ProductSupplier>();

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
            _validator ?? (_validator = new PackageValidator());

        // Validation rules for type <T> may be specified in the constructor of a class inheriting
        // from FluentValidator's AbstractValidator<T>. This is how the fluent API is exposed.
        private sealed class PackageValidator : AbstractValidator<Package>
        {
            private IValidator<ProductSupplier> _ProductSupplierValidator;
            private IValidator<ProductSupplier> ProductSupplierValidator =>
                _ProductSupplierValidator ?? (_ProductSupplierValidator = 
                (IValidator<ProductSupplier>)new ProductSupplier().GetValidator());

            public PackageValidator()
            {
                // I sometimes use int.MinValue to denote invalid IDs, so I check for that
                RuleFor(package => package.PackageId)
                    .GreaterThan(int.MinValue)
                    .WithMessage($"{nameof(PackageId)} cannot be {int.MinValue}.");

                RuleFor(package => package.Name)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage($"{nameof(Name)} is required.");

                RuleFor(package => package.StartDate)
                    .GreaterThan(new DateTime(2001, 9, 11))
                    .WithMessage("The start date cannot be earlier than the day the towers fell; September 11, 2001.");

                RuleFor(package => package.EndDate)
                    .GreaterThan(package => package.StartDate)
                    .WithMessage("The end date has to come after the start date.");

                RuleFor(package => package.Description)
                    .NotNull()
                    .WithMessage($"{nameof(Description)} is not set.");

                RuleFor(package => package.BasePrice)
                    .NotEqual(decimal.MinValue)
                    .WithMessage("Price was not understood. Please speak clearly into your computer.")
                    .GreaterThanOrEqualTo(0M)
                    .WithMessage("Price cannot be negative.");

                RuleFor(package => package.AgencyCommission)
                    .NotEqual(decimal.MinValue)
                    .WithMessage("Commission was not understood. Please speak clearly into your computer.")
                    .LessThanOrEqualTo(p => p.BasePrice)
                    .WithMessage("Commission cannot be greater than the base price.")
                    .GreaterThanOrEqualTo(0M)
                    .WithMessage("Commission cannot be negative.");

                RuleFor(package => package.ProductSuppliers)
                    .Must(AllProductSuppliersValid)
                    .WithMessage("Some product suppliers are invalid: {0}", 
                        package => ListInvalidProductSupplierNames(package.ProductSuppliers));

                // this should never actually happen
                RuleFor(package => package.ProductSuppliers)
                    .Must(list => list.TrueForAll(ps => ps != null))
                    .WithMessage("Some product suppliers are null.");
            }

            [Pure]
            private bool AllProductSuppliersValid(
                [InstantHandle][NotNull] IEnumerable<ProductSupplier> productSuppliers)
                => productSuppliers
                    .Where(productSupplier => productSupplier != null)
                    .All(productSupplier =>
                        ProductSupplierValidator.Validate(productSupplier).IsValid);

            [Pure]
            [NotNull]
            private string ListInvalidProductSupplierNames(
                [InstantHandle][NotNull] IEnumerable<ProductSupplier> productSuppliers)
                => string.Join(", ",
                    productSuppliers
                        .Where(ps => ps != null && !ProductSupplierValidator.Validate(ps).IsValid)
                        .Select(ps => ps.FullName));
        }

        #endregion

    }
}
