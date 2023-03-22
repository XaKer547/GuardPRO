using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace SF2022User01Lib.Tests
{
    public class CalculationsTest
    {
        Calculations calculations = new Calculations(); 

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AvailablePeriods_WithoutSpans()
        {
            var reuslt = calculations.AvailablePeriods(new TimeSpan[0], new int[0], new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0), 30);

            Assert.AreEqual(new string[]
            {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "10:00-10:30",
                "10:30-11:00",
                "11:00-11:30",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:00-15:30",
                "15:30-16:00",
                "16:00-16:30",
                "16:30-17:00",
                "17:00-17:30",
                "17:30-18:00"
            },
            reuslt);
        }

        [Test]
        public void AvailablePeriods_WithSpans()
        {
            var reuslt = calculations.AvailablePeriods(
                new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0) },
                new int[] { 60, 30, 10 },
                new TimeSpan(8, 0, 0),
                new TimeSpan(17, 0, 0),
                30
            );

            Assert.AreEqual(new string[]
            {
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:10-15:40",
                "15:40-16:10",
                "16:10-16:40"
            },
            reuslt);
        }

        [Test]
        public void AvailablePeriods_AllUnavaible()
        {
            var reuslt = calculations.AvailablePeriods(
                new TimeSpan[] { new TimeSpan(8, 0, 0) },
                new int[] { 60 },
                new TimeSpan(8, 0, 0),
                new TimeSpan(9, 0, 0),
                30
            );

            Assert.AreEqual(new string[] { }, reuslt);
        }
    }
}