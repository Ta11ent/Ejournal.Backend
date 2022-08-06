using Ejournal.Domain;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDay
{
    internal static class ScheduleDayAction
    {
        internal static ScheduleDay Create(Guid scheduleId, DayOfWeek day)
        {
            return new ScheduleDay
            {
                ScheduleDayId = scheduleId.ToString() + day.ToString(),
                Day = day,
                Active = true
            };
        }
    }
}
