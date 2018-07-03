using System;
using ControlsValidators.Behaviors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace ControlsValidators.Tests.NumericOnlyBehaviorTest
{
    [TestClass]
    public class NumericOnlyBehaviorTest
    {
        private NumericOnlyBehavior behavior;

        public NumericOnlyBehaviorTest()
        {
            behavior = new NumericOnlyBehavior();
        }

        [TestMethod]
        public void ValidIfNumeric()
        {
            var entry = new Entry();
            entry.Behaviors.Add(behavior);
            entry.Text = "1";
            Assert.IsTrue(((NumericOnlyBehavior)entry.Behaviors[0]).IsValid);
        }

        [TestMethod]
        public void InvalidIfNotNumeric()
        {
            var entry = new Entry();
            entry.Behaviors.Add(behavior);
            entry.Text = "a";
            Assert.IsFalse(((NumericOnlyBehavior)entry.Behaviors[0]).IsValid);
        }

        [TestMethod]
        public void InvalidIfEmpty()
        {
            var entry = new Entry();
            entry.Behaviors.Add(behavior);
            entry.Text = string.Empty;
            Assert.IsFalse(((NumericOnlyBehavior)entry.Behaviors[0]).IsValid);
        }

        [TestMethod]
        public void IsInvalidIfNUll()
        {
            var entry = new Entry();
            entry.Behaviors.Add(behavior);
            entry.Text = null;
            Assert.IsFalse(((NumericOnlyBehavior)entry.Behaviors[0]).IsValid);
        }
    }
}
