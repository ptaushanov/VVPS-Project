using VVPS_BDJ.Models;

namespace VVPS_BDJ.DAL
{
    public class BDJService
    {
        private static readonly BDJContext _bdjContext = new();

        #region Reservation Queries

        public static void StoreReservation(Reservation reservation)
        {
            _bdjContext.Reservations.Add(reservation);
            _bdjContext.SaveChanges();
        }

        public static IEnumerable<Reservation> GetAllReservations()
        {
            return _bdjContext.Reservations.AsEnumerable();
        }

        public static void ChangeReservation() => _bdjContext.SaveChanges();

        public static void CancelReservation(Reservation reservation)
        {
            reservation.Canceled = true;
            _bdjContext.SaveChanges();
        } 

        #endregion

        #region TimetableRecord Queries
        
        public static IEnumerable<TimetableRecord> FindTimetableRecordByDepartureLocation
        (
            string departureLocation
        )
        {
            return _bdjContext
                .TimetableRecords
                .Where(record => record.DepartureLocation == departureLocation);
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArivalLocation
        (
             string arrivalLocation
        )
        {
            return _bdjContext
                .TimetableRecords
                .Where(record => record.ArrivalLocation == arrivalLocation);
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByDeparuteTime
        (
            TimeOnly minTime, TimeOnly maxTime
        )
        {
            return _bdjContext
                .TimetableRecords
                .Where(record =>
                    record.DeparuteTime >= minTime &&
                    record.DeparuteTime <= maxTime
                );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArrivalTime
        (
            TimeOnly minTime, TimeOnly maxTime
        )
        {
            return _bdjContext
                .TimetableRecords
                .Where(record =>
                    record.ArrivalTime >= minTime &&
                    record.ArrivalTime <= maxTime
                );
        }

        #endregion
    }
}
