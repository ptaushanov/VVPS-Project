namespace VVPS_BDJ.Models
{
    public class Timetable
    {
        public int? TimetableID { get; set; }
        public IEnumerable<TimetableRecord> TimetableRecords { get; private set; }

        public Timetable(int? timetableId, IEnumerable<TimetableRecord> timetableRecords)
        {
            TimetableID = timetableId;
            TimetableRecords = timetableRecords;
        }
    }
}
