using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace LearningAboutMockTests
{
    enum DaysOfTheWeek
    {
        Sunday = 1,
        Monday = 5,
        Tuesday = 11,
        Wednesday = 15,
        Thursday = 21,
        Friday = 25,
        Saturday
    };

    enum DumbDaysOfTheWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    };

    class TestLearningEnum
    {
        [Test]
        public void CanAccessEnum()
        {
//            Assert.AreEqual("Sunday", DaysOfTheWeek.Sunday);
//            Assert.AreEqual(21, (int)DaysOfTheWeek.Thursday)));

            Assert.AreEqual(0, (int)DumbDaysOfTheWeek.Sunday);

            var a = DaysOfTheWeek.Friday;
            if (a == DaysOfTheWeek.Friday)
            {
                Assert.AreEqual(a, DaysOfTheWeek.Friday);
            }
        }

        [Test]
        public void WhatEnumsTryToSolve()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Sunday", 1);
            dictionary.Add("Monday", 2);
            dictionary.Add("Tuesday", 3);
            dictionary.Add("Wednesday", 4);
            dictionary.Add("Thursday", 5);
            dictionary.Add("Friday", 6);
            dictionary.Add("Saturday", 7);

            var a = dictionary["Friday"];

            if (a == 6)
            {
                Assert.AreEqual(a, 6);
            }

        }
    }
}
