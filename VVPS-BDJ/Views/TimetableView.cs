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
        Console.Write(inputMessage);
        return Console.ReadLine() ?? string.Empty;
    }

    public TimeOnly DisplayTimeSearchInput(string inputMessage)
    {
        Console.Clear();
        Console.Write(inputMessage);
        TimeOnly time;
        string? timeAsString = Console.ReadLine();
        bool isParsedSuccessfully = TimeOnly.TryParse(timeAsString, out time);

        while (!isParsedSuccessfully)
        {
            Console.WriteLine("Invalid time format. Please try again.");
            Console.Write(inputMessage);
            timeAsString = Console.ReadLine();
            isParsedSuccessfully = TimeOnly.TryParse(timeAsString, out time);
        }

        return time;
    }

    private void DisplaySingleTimetableRecord(TimetableRecord timetableRecord)
    {
        Console.WriteLine("###########################################");
        Console.WriteLine(
            $"Departure Time: {timetableRecord.DepartureTime}{Environment.NewLine}"
                + $"Arrival Time: {timetableRecord.ArrivalTime}{Environment.NewLine}"
                + $"Departure Location: {timetableRecord.DepartureLocation}{Environment.NewLine}"
                + $"Arrival Location: {timetableRecord.ArrivalLocation}"
        );
        Console.WriteLine("###########################################" + Environment.NewLine);
    }

    public void DisplayTimetableRecords(IEnumerable<TimetableRecord> timetableRecords)
    {
        Console.Clear();
        Console.WriteLine("[Timetable records]" + Environment.NewLine);

        timetableRecords.ToList().ForEach(DisplaySingleTimetableRecord);
    }
}
