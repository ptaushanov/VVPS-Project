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
                { "Search by departure location", () => SearchByDepartureLocation() },
                { "Search by arrival location", () => SearchByArrivalLocation() },
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
            "Enter the minimum departure time:"
        );
        TimeOnly departureTimeMax = _timetableView.DisplayTimeSearchInput(
            "Enter the maximum departure time:"
        );
        IEnumerable<TimetableRecord> timetableRecords =
            BDJService.FindTimetableRecordByDepartureTime(departureTimeMin, departureTimeMax);

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByTimeMenu();
    }

    private void SearchByArrivalTime()
    {
        TimeOnly arrivalTimeMin = _timetableView.DisplayTimeSearchInput(
            "Enter the minimum arrival time:"
        );
        TimeOnly arrivalTimeMax = _timetableView.DisplayTimeSearchInput(
            "Enter the maximum arrival time:"
        );
        IEnumerable<TimetableRecord> timetableRecords = BDJService.FindTimetableRecordByArrivalTime(
            arrivalTimeMin,
            arrivalTimeMax
        );

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByTimeMenu();
    }

    private void SearchByArrivalLocation()
    {
        string arrivalLocation = _timetableView.DisplayLocationSearchInput(
            "Enter the arrival location:"
        );

        IEnumerable<TimetableRecord> timetableRecords =
            BDJService.FindTimetableRecordByArrivalLocation(arrivalLocation);

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByLocationMenu();
    }

    private void SearchByDepartureLocation()
    {
        string departureLocation = _timetableView.DisplayLocationSearchInput(
            "Enter the departure location:"
        );

        IEnumerable<TimetableRecord> timetableRecords =
            BDJService.FindTimetableRecordByDepartureLocation(departureLocation);

        _timetableView.DisplayTimetableRecords(timetableRecords);
        ReturnToSearchByLocationMenu();
    }

    private void GoBack()
    {
        new MainController()
        .ShowMainMenu();
    }
}
