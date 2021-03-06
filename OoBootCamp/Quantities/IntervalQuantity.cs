﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific scale-based measurement
    public class IntervalQuantity : IEquatable<IntervalQuantity>, Sequenceable<IntervalQuantity>
    {
        private const double Tolerance = 1e-6;
        protected readonly double Amount;
        protected readonly Unit Unit;

        internal IntervalQuantity(double amount, Unit unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public bool Equals(IntervalQuantity other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            if (!this.IsCompatible(other)) return false;
            return Math.Abs(this.Amount - ConvertedAmount(other)) < Tolerance;
        }

        private bool IsCompatible(IntervalQuantity other) => this.Unit.IsCompatible(other.Unit);

        protected double ConvertedAmount(IntervalQuantity other) => this.Unit.ConvertedAmount(other.Amount, other.Unit);

        public bool IsBetterThan(IntervalQuantity other)
        {
            return this.Amount > ConvertedAmount(other);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() && Equals((IntervalQuantity)other);
        }

        public override int GetHashCode() => Unit.HashCode(Amount);
    }
}