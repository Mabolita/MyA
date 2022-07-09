using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModifiedObjectPooler<T> 
{
    private List<T> _uninstantiated = new List<T>();
    private Func<T> _factoryMethod;
    private Action<T> _turnOn;
    private Action<T> _turnOff;




    public ModifiedObjectPooler(Func<T> factoryMethod, Action<T> TurnOn, Action<T> TurnOff, int initialAmount)
    {
        _factoryMethod = factoryMethod;
        _turnOff = TurnOff;
        _turnOn = TurnOn;

        for (var i = 0; i < initialAmount; i++)
        {
            var obj = factoryMethod();
            _turnOff(obj);
            _uninstantiated.Add(obj);
        }
    }

    public T Get()
    {
        T obj;

        if(_uninstantiated.Count > 0)
        {
             obj = _uninstantiated[0];
            _uninstantiated.Remove(obj);
           
     
        }
        else
        {
             obj = _factoryMethod();
        }
        _turnOn(obj);

        return obj;
    }

    public void ReturnToPool(T obj)
    {
        _uninstantiated.Add(obj);
        _turnOff(obj);
    }


}
