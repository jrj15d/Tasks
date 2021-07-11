using NUnit.Framework;
using System;
using Tasks.Models;

namespace TasksTests
{
    [TestFixture]
    public class ProgressTasksTests
    {
        private ProgressTask task3y3m3d;

        [SetUp]
        public void SetUp()
        {
            string title = "Lose Weight";
            string description = "Lose 10 pounds";
            bool completed = false;
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue.AddYears(3).AddMonths(3).AddDays(3);
            float progress = 0;

            task3y3m3d = new ProgressTask(title, description, completed, start, end, progress);
        }

        [Test]
        public void DateRange_3Months()
        {
            var expected = new DateTime(4, 4, 4);
            var result = task3y3m3d.DateRange;
            Assert.AreEqual(expected.Date, result.Date, "Date range should be 3 years, 3 months, and 3 days apart.");
        }

        [Test]
        public void Completed_IsFalse()
        {
            Assert.IsFalse(task3y3m3d.Completed, "This task should not be completed.");
        }
    }
}