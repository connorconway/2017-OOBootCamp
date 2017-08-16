﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using OoBootCamp.Quantities.ExtensionMethods;
using static OoBootCamp.Quantities.Unit;

namespace OoBootCamp.Tests.Quantities
{
    // Ensures Quantity operates correctly
    [TestFixture]
    public class QuantityTest
    {

        [Test]
        public void EqualityOfLikeUnits()
        {
            Assert.AreEqual(Tablespoon.S(6), Tablespoon.S(6));
            Assert.AreNotEqual(Tablespoon.S(6), Tablespoon.S(5));
            Assert.AreNotEqual(Tablespoon.S(6), new object());
            Assert.AreNotEqual(Tablespoon.S(6), null);
        }

        [Test]
        public void EqualityOfUnlikeUnits()
        {
            Assert.AreEqual(Tablespoon.S(6), Ounce.S(3));
            Assert.AreEqual(Tablespoon.S(8), Cup.S(0.5));
            Assert.AreEqual(Cup.S(0.5), Tablespoon.S(8));
            Assert.AreEqual(Gallon.S(2), Teaspoon.S(1536));
            Assert.AreNotEqual(Cup.S(6), Tablespoon.S(6));

            Assert.AreEqual(6.Tablespoons(), 3.Ounces());
            Assert.AreEqual(8.Tablespoons(), 0.5.Cups());
            Assert.AreEqual(0.5.Cups(), 8.Tablespoons());
            Assert.AreEqual(2.Gallons(), 1536.Teaspoons());
            Assert.AreNotEqual(6.Cups(), 6.Tablespoons());
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(Tablespoon.S(8).GetHashCode(), Cup.S(0.5).GetHashCode());
        }

        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(Tablespoon.S(-3), -Tablespoon.S(3));
            Assert.AreEqual(-Cup.S(1.5), Cup.S(6.5) - Cup.S(8));
            Assert.AreEqual(-Tablespoon.S(24), Cup.S(6.5) - Gallon.S(0.5));
            Assert.AreEqual(-24.Tablespoons(), 6.5.Cups() - 0.5.Gallons());
        }
    }
}