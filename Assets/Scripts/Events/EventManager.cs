using UnityEngine.Events;

public class EventManager
{
    public static readonly UnityEvent<int> CoinPickedUp = new();

    public static void CallCoinPickedUp(int reward)
    {
        CoinPickedUp?.Invoke(reward);
    }
}
