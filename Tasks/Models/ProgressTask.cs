using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class ProgressTask : Task
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Progress { get; set; }
        public DateTime DateRange
        {
            get
            {
                // only calculate delta if start and end dates aren't null
                if (StartDate is DateTime && EndDate is DateTime)
                {
                    TimeSpan delta = EndDate - StartDate;
                    return new DateTime(delta.Ticks);
                }

                else
                    return DateTime.MinValue;
            }
        }

        public ProgressTask() { }
        public ProgressTask(string title, string description, DateTime startDate, DateTime endDate, float progress)
            : base(title, description)
        {
            StartDate = startDate;
            EndDate = endDate;
            Progress = progress;
        }

    }
}
