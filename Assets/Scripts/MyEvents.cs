using System;

public static class MyEvents
{
    public static event Action<int> SomeEvent;

    public static void InvokeSomeEvent(int value)
    {
        // Make sure event is only invoked if someone is listening
        if (SomeEvent == null) return;

        SomeEvent.Invoke(value);
    }
}