﻿using VVPS_BDJ.Models;

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

        public static IEnumerable<Reservation> FindAllReservations() =>
            _bdjContext.Reservations.AsEnumerable();

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

        public static IEnumerable<TimetableRecord> FindTimetableRecordByArivalLocation(
            string arrivalLocation
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.ArrivalLocation == arrivalLocation
            );
        }

        public static IEnumerable<TimetableRecord> FindTimetableRecordByDeparuteTime(
            TimeOnly minTime,
            TimeOnly maxTime
        )
        {
            return _bdjContext.TimetableRecords.Where(
                record => record.DeparuteTime >= minTime && record.DeparuteTime <= maxTime
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

        #endregion

        #region User Queries

        public static void AddUser(User user)
        {
            _bdjContext.Users.Add(user);
            _bdjContext.SaveChanges();
        }

        public static void UpdateUser() => _bdjContext.SaveChanges();

        public static IEnumerable<User> FindAllUsers() => _bdjContext.Users.AsEnumerable();

        public static User? FindUserById(int userId) =>
            _bdjContext.Users.FirstOrDefault(user => user.UserId == userId);

        public static User? FindAdminByUsernameAndPassword(string username, string password)
        {
            return _bdjContext.Users.FirstOrDefault(
                user =>
                    user.Username == username && user.Password == password && user.IsAdmin == true
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
