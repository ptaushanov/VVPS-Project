namespace VVPS_BDJ.Models
{
    public class TimetableRecord
    {
        public int? TimetableRecordId { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }

        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }

        public TimetableRecord() { }
        public TimetableRecord(
            int? timetableRecordId, string departureLocation,
            string arrivalLocation, TimeOnly departureTime, TimeOnly arrivalTime
        )
        {
            TimetableRecordId = timetableRecordId;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }
    }
}
