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
                ScheduleDayId = GenerateDayId(scheduleId, day),
                ScheduleId = scheduleId,
                Day = day,
                Active = true
            };
        }

        internal static string GenerateDayId(Guid scheduleId, int day) =>
                scheduleId.ToString() + day.ToString();
    }
}
