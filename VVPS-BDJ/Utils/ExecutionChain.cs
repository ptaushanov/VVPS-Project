namespace VVPS_BDJ.Utils;

public class ExecutionChain
{
    private readonly List<Func<bool>> _funcs;

    public ExecutionChain()
    {
        _funcs = new List<Func<bool>>();
    }

    public ExecutionChain Add(Func<bool> func)
    {
        _funcs.Add(func);
        return this;
    }

    public ExecutionChain Execute()
    {
        foreach (var func in _funcs)
        {
            bool didReturnTrue = func();
            if (!didReturnTrue)
                break;
        }

        return this;
    }
}
