using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_PlayerCombat
{
    [UnityTest]
    public IEnumerator Test_PlayerExplodeMove()
    {
        float power = 10.0f;
        float waitTime = 2.0f;

        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();

        PlayerCombat combat = new PlayerCombat(power, waitTime, gm.GetComponent<Rigidbody2D>());
        combat.Explode();

        yield return new WaitForSeconds(waitTime / 2);

        Assert.AreNotEqual(0.0f, gm.GetComponent<Rigidbody2D>().velocity.y);

        yield return null;
    }

    [UnityTest]
    public IEnumerator Test_PlayerExplodeCooldown()
    {
        float power = 10.0f;
        float waitTime = 2.0f;

        GameObject gm = new GameObject();
        gm.AddComponent<Rigidbody2D>();

        PlayerCombat combat = new PlayerCombat(power, waitTime, gm.GetComponent<Rigidbody2D>());
        combat.Explode();
        yield return new WaitForSeconds(waitTime / 2);
        Assert.AreEqual(false, combat.CanExplode());

        yield return new WaitForSeconds(waitTime / 2);
        Assert.AreEqual(true, combat.CanExplode());

        yield return null;
    }
}
