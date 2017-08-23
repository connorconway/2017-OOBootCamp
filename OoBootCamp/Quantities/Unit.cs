/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific metric
    public class Unit
    {
        public static readonly RatioUnit Teaspoon = new RatioUnit();
        public static readonly RatioUnit Tablespoon = new RatioUnit(3, Teaspoon);
        public static readonly RatioUnit Ounce = new RatioUnit(2, Tablespoon);
        public static readonly RatioUnit Cup = new RatioUnit(8, Ounce);
        public static readonly RatioUnit Pint = new RatioUnit(2, Cup);
        public static readonly RatioUnit Quart = new RatioUnit(2, Pint);
        public static readonly RatioUnit Gallon = new RatioUnit(4, Quart);

        public static readonly RatioUnit Inch = new RatioUnit();
        public static readonly RatioUnit Foot = new RatioUnit(12, Inch);
        public static readonly RatioUnit Yard = new RatioUnit(3, Foot);
        public static readonly RatioUnit Furlong = new RatioUnit(220, Yard);
        public static readonly RatioUnit Mile = new RatioUnit(8, Furlong);

        public static readonly IntervalUnit Celsius = new IntervalUnit();
        public static readonly IntervalUnit Fahrenheit = new IntervalUnit(5/9.0, 32, Celsius);

        private const int DecimalPlaceCount = 6;
        private readonly double _baseUnitRatio;
        private readonly double _offset;
        private readonly Unit _baseUnit;

        private Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1;
            _offset = 0;
        }

        private Unit(double relativeRatio, double offset, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _offset = offset;
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new InvalidOperationException("Mixed Unit arithmetic");
            return (otherAmount - other._offset) * other._baseUnitRatio / this._baseUnitRatio + this._offset;
        }

        internal int HashCode(double amount) 
            => Math.Round((amount - _offset) * _baseUnitRatio, DecimalPlaceCount).GetHashCode();

        internal bool IsCompatible(Unit otherUnit) => this._baseUnit == otherUnit._baseUnit;

        public class RatioUnit : Unit
        {
            internal RatioUnit() { }
            internal RatioUnit(double relativeRatio, Unit relativeUnit) : 
                base(relativeRatio, 0, relativeUnit) { }

            public RatioQuantity S(double amount) => new RatioQuantity(amount, this);

            public RatioQuantity Es(double amount) => this.S(amount);
        }

        public class IntervalUnit : Unit
        {
            internal IntervalUnit() { }
            internal IntervalUnit(double relativeRatio, double offset, Unit relativeUnit) : 
                base(relativeRatio, offset, relativeUnit) { }

            public IntervalQuantity S(double amount) => new IntervalQuantity(amount, this);

            public IntervalQuantity Es(double amount) => this.S(amount);
        }
    }
}