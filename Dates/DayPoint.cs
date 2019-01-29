using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Standard.Dates
{
    public class DayPoint : IComparable
    {
        /// <summary>
        /// Represents day in the year. Possible values 1 - 365(366)
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Represents year. All values possible.
        /// </summary>
        public int Year { get; set; }

        public DayPoint() { }

        public DayPoint(int year, int day)
        {
            this.Year = year;
            this.Day = day;
        }

        public DayPoint(DateTime date)
            : this(date.Year, date.DayOfYear)
        { }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            DayPoint other = obj as DayPoint;

            if (other == null)
                throw new ArgumentException($"It's not a {nameof(DayPoint)}");

            var yearDiff = Year - other.Year;

            if (yearDiff != 0)
                return yearDiff;

            return Day - other.Day;
        }

        public DateTime ToDateTime()
        {
            var d = new DateTime(Year, 1, 1);

            return d.AddDays(Day - 1);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as DayPoint);
        }

        public bool Equals(DayPoint other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(other, this))
                return true;

            if (other.GetType() != this.GetType())
                return false;

            return (other.Day == Day) && (other.Year == Year);
        }

        public static bool operator ==(DayPoint lhs, DayPoint rhs)
        {
            if(Object.ReferenceEquals(lhs, null))
            {
                return Object.ReferenceEquals(lhs, rhs);
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(DayPoint lhs, DayPoint rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return $"{Year} - {Day}";
        }
    }
}
