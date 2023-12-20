using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_ObjectMovement
{
    [UnityTest]
    public IEnumerator Test_ObjectMove()
    {
        float speed = 10.0f;
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        ObjectMovement ob = new ObjectMovement(speed, gm.GetComponent<Rigidbody2D>());
        ob.StartPush();
        ob.MoveWorks();

        Assert.AreEqual(gm.GetComponent<Rigidbody2D>().velocity.x,
            InputManager.GetHoriontalValue() * speed * Time.fixedDeltaTime);
            
        yield return null;
    }

    [UnityTest]
    public IEnumerator Test_ObjectStopPush()
    {
        float speed = 10.0f;
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        ObjectMovement ob = new ObjectMovement(speed, gm.GetComponent<Rigidbody2D>());
        
        ob.StartPush();
        ob.MoveWorks();
        ob.StopPush();

        Assert.AreEqual(gm.GetComponent<Rigidbody2D>().velocity.x, 0.0f);

        yield return null;
    }
    [UnityTest]
    public IEnumerator Test_ObjectGetSpeed()
    {
        float speed = 10.0f;
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        ObjectMovement ob = new ObjectMovement(speed, gm.GetComponent<Rigidbody2D>());

        Assert.AreEqual(speed, ob.GetPushSpeed());
        
        yield return null;
    }
}
