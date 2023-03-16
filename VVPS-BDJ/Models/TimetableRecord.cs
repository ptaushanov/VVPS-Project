namespace VVPS_BDJ.Models
{
    public class TimetableRecord
    {
        public int? TimetableRecordId { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }

        public TimeOnly DeparuteTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }

        public TimetableRecord() {}
        public TimetableRecord(
            int? timetableRecordId, string departureLocation,
            string arrivalLocation, TimeOnly deparuteTime, TimeOnly arrivalTime
        )
        {
            TimetableRecordId = timetableRecordId;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DeparuteTime = deparuteTime;
            ArrivalTime = arrivalTime;
        }
    }
}
