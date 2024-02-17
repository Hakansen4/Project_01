using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth
{
    private float health;

    public PlayerHealth(float health)
    {
        this.health = health;
    }

    public void Hit(float damage)
    {
        //Not pushing right now...
        Debug.Log(damage + " Damage Taken");
    }
}
