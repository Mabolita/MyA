using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void EventParams(params object[] parameters);
    Dictionary<string, EventParams> _dic = new Dictionary<string, EventParams>();
    public static EventManager Instance;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(this);
        }
    }
    public void SubEvent(string nameEvent, EventParams action)
    {
        if (_dic.ContainsKey(nameEvent))
        {
            _dic[nameEvent] += action;
        }
        else
        {
            _dic.Add(nameEvent, action);
        }
    }
    public void UnSubEvent(string nameEvent, EventParams action)
    {
        if (_dic.ContainsKey(nameEvent))
        {
            _dic[nameEvent] 
                = action;
        }
    }
    public void CallEvent(string nameEvent, params object[] parameters)
    {
        if(_dic.ContainsKey(nameEvent))
        {
            _dic[nameEvent](parameters);
        }
    }
  
}
