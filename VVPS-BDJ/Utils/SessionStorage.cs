namespace VVPS_BDJ.Utils;

public static class SessionStorage
{
    private static readonly Dictionary<string, object> _localStorage = new();

    public static object? GetItem(string key)
    {
        if (_localStorage.ContainsKey(key))
        {
            return _localStorage[key];
        }

        return null;
    }

    public static void SetItem(string itemName, object itemValue)
    {
        if (_localStorage.ContainsKey(itemName))
            _localStorage[itemName] = itemValue;
        else
            _localStorage.Add(itemName, itemValue);
    }

    public static void SetItem(KeyValuePair<string, object> item)
    {
        if (_localStorage.ContainsKey(item.Key))
            _localStorage[item.Key] = item.Value;
        else
            _localStorage.Add(item.Key, item.Value);
    }

    public static void RemoveItem(string itemName)
    {
        if (_localStorage.ContainsKey(itemName))
            _localStorage.Remove(itemName);
    }

    public static void Clear()
    {
        _localStorage.Clear();
    }
}