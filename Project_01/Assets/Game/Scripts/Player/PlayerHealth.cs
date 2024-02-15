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
    public void TakeDamage(float value)
    {
        Debug.Log(value + " Damage Taken");
    }
}
