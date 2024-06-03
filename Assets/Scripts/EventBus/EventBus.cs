using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private static EventBus instance;
    public static EventBus Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventBus>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "EventBus";
                    instance = obj.AddComponent<EventBus>();
                }
            }
            return instance;
        }
    }

    private List<IEventListener> listeners = new List<IEventListener>();

    public void Emit(Event e)
    {
        foreach (var listener in listeners)
        {
            listener?.OnEvent(e); 
        }
    }

    public void Register(IEventListener listener)
    {
        listeners.Add(listener);
    }
    public void Unregister(IEventListener listener) 
    {
        listeners.Remove(listener); 
    }
}
