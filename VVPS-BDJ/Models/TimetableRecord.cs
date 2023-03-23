namespace VVPS_BDJ.Models
{
    // Basically a record that stores information about a train
    public class TimetableRecord
    {
        public int? TimetableRecordId { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }

        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }

        public double TravelPrice { get; set; }

        public TimetableRecord()
        {
            DepartureLocation = string.Empty;
            ArrivalLocation = string.Empty;
        }

        public TimetableRecord(
            int? timetableRecordId, string departureLocation, string arrivalLocation,
             TimeOnly departureTime, TimeOnly arrivalTime, double travelPrice
        )
        {
            TimetableRecordId = timetableRecordId;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            TravelPrice = travelPrice;
        }
    }
}
