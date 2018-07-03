using System;
using ControlsValidators.Behaviors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace ControlsValidators.Tests.NumericOnlyBehaviorTest
{
    [TestClass]
    public class EmptyBehaviorTest
    {
        private readonly EmptyBehavior behavior;
        private readonly Entry entry;


        public EmptyBehaviorTest()
        {
            behavior = new EmptyBehavior();
            entry = new Entry();
            entry.Behaviors.Add(behavior);
        }

        [TestMethod]
        public void ValidIfNotEmpty()
        {
            entry.Text = "1";
            Assert.IsTrue(((EmptyBehavior)entry.Behaviors[0]).IsValid);
        }

        [TestMethod]
        public void InvalidIfEmpty()
        {
            entry.Text = string.Empty;
            Assert.IsFalse(((EmptyBehavior)entry.Behaviors[0]).IsValid);
        }

        [TestMethod]
        public void IsInvalidIfNUll()
        {
            entry.Text = null;
            Assert.IsFalse(((EmptyBehavior)entry.Behaviors[0]).IsValid);
        }
    }
}
