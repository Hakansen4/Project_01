using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPoolable
{
    public void Activate();
    public void DeActivate();
}