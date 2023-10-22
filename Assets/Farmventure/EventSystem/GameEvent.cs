using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Ranchantment/New Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void Register(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void Unregister(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}
