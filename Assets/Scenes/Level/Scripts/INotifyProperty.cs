using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INotifyProperty<T>
{
    public event Action<T> PropertyChanged;
}
