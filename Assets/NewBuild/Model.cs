using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public event Action<int> changeIntAction;
    
    public void RefreshCount(int a)
    {
        Debug.Log(3);
        changeIntAction?.Invoke(a);
    }
}
