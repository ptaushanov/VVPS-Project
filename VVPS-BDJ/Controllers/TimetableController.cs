using VVPS_BDJ.DAL;
using VVPS_BDJ.Models;
using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers;

public class TimetableController
{
    private readonly TimetableView _timetableView;

    // When I can't be bothered to use dependency injection
    public TimetableController()
    {
        Dictionary<string, Action> locationSearchMenuItems =
            new()
            {
                { "Search by departure and arrival location", () => SearchByDepartureArrivalLocation() },
                { "Go Back", () => GoBack() },
            };

        Dictionary<string, Action> timeSearchMenuItems =
            new()
            {
                { "Search by departure time", () => SearchByDepartureTime() },
                { "Search by arrival time", () => SearchByArrivalTime() },
                { "Go Back", () => GoBack() },
            };

        _timetableView = new TimetableView(locationSearchMenuItems, timeSearchMenuItems);
    }

    public TimetableController(TimetableView timetableView) => _timetableView = timetableView;

    public void ShowSearchByTimeMenu()
    {
        _timetableView.DisplayTimeSearchMenu();
    }

    public void ShowSearchByLocationMenu()
    {
        _timetableView.DisplayLocationSearchMenu();
    }

    private void ReturnToSearchByTimeMenu()
    {
        _timetableView.DisplayPause();
        _timetableView.DisplayTimeSearchMenu();
    }

    private void ReturnToSearchByLocationMenu()
    {
        _timetableView.DisplayPause();
        _timetableView.DisplayLocationSearchMenu();
    }

    private void SearchByDepartureTime()
    {
        TimeOnly departureTimeMin = _timetableView.DisplayTimeSearchInput(
            "Minimum departure time: "
        );
        TimeOnly departureTimeMax = _timetableView.DisplayTimeSearchInput(
            "Maximum departure time: "
        );
        IEnumerable<TimetableRecord> timetableRecords =
            BdjService.FindTimetableRecordByDepartureTime(departureTimeMin, departureTimeMax);

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByTimeMenu();
    }

    private void SearchByArrivalTime()
    {
        TimeOnly arrivalTimeMin = _timetableView.DisplayTimeSearchInput(
            "Minimum arrival time: "
        );
        TimeOnly arrivalTimeMax = _timetableView.DisplayTimeSearchInput(
            "Maximum arrival time: "
        );
        IEnumerable<TimetableRecord> timetableRecords = BdjService.FindTimetableRecordByArrivalTime(
            arrivalTimeMin,
            arrivalTimeMax
        );

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByTimeMenu();
    }

    private void SearchByDepartureArrivalLocation()
    {
        string departureLocation = _timetableView.DisplayLocationSearchInput(
            "Departure location: "
        );

        string arrivalLocation = _timetableView.DisplayLocationSearchInput(
            "Arrival location: "
        );

        IEnumerable<TimetableRecord> timetableRecords =
            BdjService.FindTimetableRecordByLocations(departureLocation, arrivalLocation);

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByLocationMenu();
    }

    private void GoBack()
    {
        new MainController()
        .ShowMainMenu();
    }
}
