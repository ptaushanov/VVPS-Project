using VVPS_BDJ.Models;

namespace VVPS_BDJ.Utils
{
    public class TimetableManager
    {
        public static IEnumerable<TimetableRecord> FindTimetableRecordByDepartureLocation
        (
            Timetable timetable, string departureLocation
        )
        {
            if (timetable == null) throw new ArgumentNullException(nameof(timetable));
            return timetable
                .TimetableRecords
                .Where(record => record.DepartureLocation == departureLocation);
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArivalLocation
        (
            Timetable timetable, string arrivalLocation
        )
        {
            if (timetable == null) throw new ArgumentNullException(nameof(timetable));
            return timetable
                .TimetableRecords
                .Where(record => record.ArrivalLocation == arrivalLocation);
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByDeparuteTime
        (
            Timetable timetable, TimeOnly minTime, TimeOnly maxTime
        )
        {
            return timetable
                .TimetableRecords
                .Where(record =>
                    record.DeparuteTime >= minTime &&
                    record.DeparuteTime <= maxTime
                );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArrivalTime
        (
            Timetable timetable, TimeOnly minTime, TimeOnly maxTime
        )
        {
            return timetable
                .TimetableRecords
                .Where(record =>
                    record.ArrivalTime >= minTime &&
                    record.ArrivalTime <= maxTime
                );
        }

    }
}
