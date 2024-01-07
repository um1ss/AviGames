using System;

public class EventBus
{
    private static EventBus _instance;

    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EventBus();

            return _instance;
        }
    }

    public Action OnStartCheckAds;
    public Action<string> OnTransitionScene;
}