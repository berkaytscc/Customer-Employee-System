using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private UnityEvent _response;

    private void OnEnable()
    {
        _gameEvent.Register(this);
    }

    private void OnDisable()
    {
        _gameEvent.Unregister(this);
    }

    public void OnEventRaised()
    {
        _response.Invoke();
    }
}
