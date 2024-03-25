using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : PlatformObject
{
    protected override void React(IHittable hitObject)
    {
        hitObject.PushReverse(transform.position);
    }
}
