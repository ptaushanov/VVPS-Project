using Microsoft.EntityFrameworkCore;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.DAL
{
    public class BDJService
    {
        private static readonly BDJContext _bdjContext = new();

        #region Reservation Queries

        public static void AddReservation(Reservation reservation)
        {
            _bdjContext.Reservations.Add(reservation);
            _bdjContext.SaveChanges();
        }

        public static IEnumerable<Reservation> FindAllUserReservations(int userId, bool includeCanceled)
        {
            if (!includeCanceled)
                return _bdjContext.Reservations
                .Where(reservation =>
                    reservation.UserId == userId
                    && !reservation.Canceled
                )
                .Include(reservation => reservation.ReservedTickets);

            return _bdjContext.Reservations
            .Where(reservation => reservation.UserId == userId)
            .Include(reservation => reservation.ReservedTickets);
        }

        public static void ChangeReservation() => _bdjContext.SaveChanges();

        public static void CancelReservation(Reservation reservation)
        {
            reservation.Canceled = true;
            _bdjContext.SaveChanges();
        }

        #endregion

        #region TimetableRecord Queries

        public static IEnumerable<TimetableRecord> FindTimetableRecordByDepartureLocation(
            string departureLocation
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.DepartureLocation == departureLocation
            );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArrivalLocation(
            string arrivalLocation
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.ArrivalLocation == arrivalLocation
            );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByLocations(
            string departureLocation,
            string arrivalLocation
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.DepartureLocation == departureLocation &&
                    record.ArrivalLocation == arrivalLocation
            );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByDepartureTime(
            TimeOnly minTime,
            TimeOnly maxTime
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.DepartureTime >= minTime && record.DepartureTime <= maxTime
            );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArrivalTime(
            TimeOnly minTime,
            TimeOnly maxTime
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.ArrivalTime >= minTime && record.ArrivalTime <= maxTime
            );
        }

        public static IEnumerable<TimetableRecord> FindAllTimetableRecords()
        {
            return _bdjContext.TimetableRecords.AsEnumerable();
        }

        #endregion

        #region User Queries

        public static void AddUser(User user)
        {
            _bdjContext.Users.Add(user);
            _bdjContext.SaveChanges();
        }

        public static void UpdateUser() => _bdjContext.SaveChanges();

        public static IEnumerable<User> FindAllUsers()
        {
            return _bdjContext.Users
            .Include(user => user.DiscountCard)
            .AsEnumerable();
        }

        public static User? FindUserById(int userId) =>
            _bdjContext.Users.FirstOrDefault(user => user.UserId == userId);

        public static User? FindUserByUsernameAndPassword(string username, string password)
        {
            return _bdjContext.Users.FirstOrDefault(
                user =>
                    user.Username == username && user.Password == password
            );
        }

        #endregion

        #region Discount Queries

        public static void AddDiscountCard(DiscountCard discountCard)
        {
            if (discountCard is ElderlyDiscountCard elderlyDiscountCard)
                _bdjContext.DiscountCards.Add(elderlyDiscountCard);
            else if (discountCard is FamilyDiscountCard familyDiscountCard)
                _bdjContext.DiscountCards.Add(familyDiscountCard);
            _bdjContext.SaveChanges();
        }

        public static void UpdateDiscountCard() => _bdjContext.SaveChanges();

        public static void DeleteDiscountCard(DiscountCard discountCard)
        {
            if (discountCard is ElderlyDiscountCard elderlyDiscountCard)
                _bdjContext.DiscountCards.Remove(elderlyDiscountCard);
            else if (discountCard is FamilyDiscountCard familyDiscountCard)
                _bdjContext.DiscountCards.Remove(familyDiscountCard);
            _bdjContext.SaveChanges();
        }

        #endregion
    }
}
