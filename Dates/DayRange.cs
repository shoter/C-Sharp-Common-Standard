using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.Dates
{
    public class DayRange
    {
        private readonly DayPoint startDay, endDay;

        public DayPoint StartDay => startDay;
        public DayPoint EndDay => endDay;
        
        public DayRange(DayPoint start, DayPoint end)
        {
            //Debug.Assert(start.Year <= end.Year);
            //Debug.Assert(start.Day <= end.Day);
            this.startDay = start;
            this.endDay = end;
        }

        public void ForEach(Action<DayPoint> action)
        {
            DayPoint current = StartDay;
            DateTime yearDate = new DateTime(current.Year, 12, 31);

            while(current != endDay)
            {
                action.Invoke(current);

                
                if(current.Day == yearDate.DayOfYear)
                {
                    current = new DayPoint(current.Year + 1, 1);
                    yearDate = new DateTime(current.Year, 12, 31);
                }
                else
                {
                    current = new DayPoint(current.Year, current.Day + 1);
                }
            }

        }

    }
}
