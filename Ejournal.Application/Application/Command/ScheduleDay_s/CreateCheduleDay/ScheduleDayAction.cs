using Ejournal.Domain;
using System;


namespace Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDay
{
    internal static class ScheduleDayAction
    {
        internal static ScheduleDay Create(Guid scheduleId, int day)
        {
            return new ScheduleDay
            {
                ScheduleDayId = scheduleId.ToString() + day.ToString(),
                ScheduleId = scheduleId,
                Day = day,
                Active = true
            };
        }
    }
}
