using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T, P> 
{
    T Create(P obj);
}
public interface IFactory<T>
{
    T Create();
}
