using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrap : PlatformObject
{
    protected override void React(IHittable hitObject)
    {
        hitObject.Hit(0, Vector2.zero, GlobalValue.InstantKillValue);
    }
}
