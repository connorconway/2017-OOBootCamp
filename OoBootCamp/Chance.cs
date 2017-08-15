﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using OoBootCamp;

namespace OoBootCamp
{
    // Understands the likelihood of something occurring
    public class Chance : IEquatable<Chance>
    {
        private const double CertainFraction = 1.0;
        private const double Tolerance = 1e-6;
        private readonly double _fraction;


        public Chance(double likelihoodAsFraction)
        {
            _fraction = likelihoodAsFraction;
        }

        public bool Equals(Chance other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return Math.Abs(this._fraction - other._fraction) < Tolerance;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return other.GetType() == this.GetType() && Equals((Chance) other);
        }

        public override int GetHashCode()
        {
            return Math.Round(_fraction, 6).GetHashCode();
        }

        public static Chance operator !(Chance c) => new Chance(CertainFraction - c._fraction);

        public Chance Not() => !this;

        public Chance And(Chance other) => new Chance(this._fraction * other._fraction);

        public static Chance operator &(Chance left, Chance right) => left.And(right);

        public static Chance operator |(Chance left, Chance right) => !(!left & !right);

        public Chance Or(Chance other) => this | other;
    }
}

namespace ExtensionMethods
{
    public static class ChanceConstructors
    {
        public static Chance Chance(this double fraction) => new Chance(fraction);

        public static Chance Chance(this int wholeNumber) => new Chance(wholeNumber);
    }
}