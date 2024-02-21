using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_PlayerMovement
{
    [UnityTest]
    public IEnumerator Test_PlayerRun()
    {
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        float runningSpeed = 10.0f;
        float jumpPower = 10.0f;

        PlayerMovement movement = new PlayerMovement(runningSpeed, gm.GetComponent<Rigidbody2D>(),
            gm.GetComponent<Transform>(), jumpPower,0);


        movement.Run();

        Assert.AreEqual(runningSpeed * Time.fixedDeltaTime * InputManager.GetHoriontalValue()
                        , gm.GetComponent<Rigidbody2D>().velocity.x);


        yield return null;
    }

    [UnityTest]
    public IEnumerator Test_PlayerPush()
    {
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        float runningSpeed = 10.0f;
        float jumpPower = 10.0f;
        float pushSpeed = 10.0f;

        PlayerMovement movement = new PlayerMovement(runningSpeed, gm.GetComponent<Rigidbody2D>(),
            gm.GetComponent<Transform>(), jumpPower, 0);

        movement.PushMove(pushSpeed);

        Assert.AreEqual(pushSpeed * Time.fixedDeltaTime * InputManager.GetHoriontalValue()
                        , gm.GetComponent<Rigidbody2D>().velocity.x);


        yield return null;
    }

    [UnityTest]
    public IEnumerator Test_PlayerJump() 
    {
        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();
        float runningSpeed = 10.0f;
        float jumpPower = 10.0f;

        PlayerMovement movement = new PlayerMovement(runningSpeed, gm.GetComponent<Rigidbody2D>(),
            gm.GetComponent<Transform>(), jumpPower, 0);

        movement.Jump();

        yield return new WaitForSeconds(0.1f);

        Assert.AreNotEqual(0.0f, gm.GetComponent<Rigidbody2D>().velocity.y);

        yield return null;
    }
}
