using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;

public class TimetableView : View
{
    private readonly IEnumerable<KeyValuePair<string, Action>> _locationSearchMenuItems;
    private readonly IEnumerable<KeyValuePair<string, Action>> _timeSearchMenuItems;

    public TimetableView(
        IEnumerable<KeyValuePair<string, Action>> locationSearchMenuItems,
        IEnumerable<KeyValuePair<string, Action>> timeSearchMenuItems
        )
    {
        _locationSearchMenuItems = locationSearchMenuItems;
        _timeSearchMenuItems = timeSearchMenuItems;
    }

    public void DisplayLocationSearchMenu()
    {
        ConsoleMenu locationSearchMenu = new(_locationSearchMenuItems, "Location Search Menu");
        locationSearchMenu.Show();
    }

    public void DisplayTimeSearchMenu()
    {
        ConsoleMenu timeSearchMenu = new(_timeSearchMenuItems, "Time Search Menu");
        timeSearchMenu.Show();
    }

    public string DisplayLocationSearchInput(string inputMessage)
    {
        Console.Clear();
        Console.WriteLine(inputMessage);
        return Console.ReadLine() ?? string.Empty;
    }

    public TimeOnly DisplayTimeSearchInput(string inputMessage)
    {
        Console.Clear();
        Console.WriteLine(inputMessage);
        return TimeOnly.Parse(Console.ReadLine() ?? string.Empty);
    }

    private string FormatTimetableRecord(TimetableRecord timetableRecord)
    {
        string formattedTimetableRecord =
            $"Departure Time: {timetableRecord.DepartureTime}" +
            $"Arrival Time: {timetableRecord.ArrivalTime}" +
            $"Departure Location: {timetableRecord.DepartureLocation}" +
            $"Arrival Location: {timetableRecord.ArrivalLocation}";
        return formattedTimetableRecord;
    }

    public void DisplayTimetableRecords(IEnumerable<TimetableRecord> timetableRecords)
    {
        Console.WriteLine("Timetable records:");
        timetableRecords
            .ToList()
            .ForEach(timetableRecord =>
            {
                Console.WriteLine(FormatTimetableRecord(timetableRecord));
                Console.WriteLine();
            });
    }
}
