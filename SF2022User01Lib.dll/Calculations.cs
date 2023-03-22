using System;
using System.Collections.Generic;
using System.Linq;

namespace SF2022User01Lib
{
    public class Calculations
    {
        private (bool, int?) IsAvaibleTime(TimeSpan[] startTimes, int[] durations, TimeSpan currentTime)
        {
            for (int i = 0; i < startTimes.Length; i++)
            {
                if (currentTime >= startTimes[i] && currentTime < startTimes[i].Add(TimeSpan.FromMinutes(durations[i])))
                    return (false, i);
            }

            return (true, null);
        }

        public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            var consultationTimeSpan = TimeSpan.FromMinutes(consultationTime);


            var allTimeSpanes = new List<TimeSpan>();

            TimeSpan currentTime = beginWorkingTime;
            while (currentTime.Add(consultationTimeSpan) <= endWorkingTime)
            {
                (bool isAvaible, int? startTimesIndex) = IsAvaibleTime(startTimes, durations, currentTime);
                if (isAvaible)
                {
                    allTimeSpanes.Add(currentTime);
                    currentTime = currentTime.Add(consultationTimeSpan);
                }
                else
                {
                    currentTime = startTimes[(int)startTimesIndex].Add(TimeSpan.FromMinutes(durations[(int)startTimesIndex]));
                }s
            }

            string format = @"hh\:mm";
            return allTimeSpanes.Select(x => $"{x.ToString(format)}-{x.Add(consultationTimeSpan).ToString(format)}").ToArray();
        }
    }
}
