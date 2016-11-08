// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using JetBrains.Annotations;

namespace TravelDatabase
{
    /// <summary>
    ///     Used to track authorship across the source code.
    /// </summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public abstract class AuthorAttribute : Attribute
    {
        public abstract string Name { get; }
    }

    public sealed class DevinAttribute : AuthorAttribute
    {
        public override string Name => "Devin";
    }

    public sealed class ChadAttribute : AuthorAttribute
    {
        public override string Name => "Chad";
    }

    public sealed class HeidiAttribute : AuthorAttribute
    {
        public override string Name => "Heidi";
    }

    public sealed class EjAttribute : AuthorAttribute
    {
        public override string Name => "EJ";
    }
}