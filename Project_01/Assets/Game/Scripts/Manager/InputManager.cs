using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private const string HORIZONTAL = "Horizontal";

    public static bool CheckMoveInput()
    {
        if(Input.GetAxis(HORIZONTAL) != 0)
        {
            return true;
        }
        return false;
    }
    public static bool CheckJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            return true;
        return false;
    }

    public static bool CheckCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
            return true;
        return false;
    }
    public static float GetHoriontalValue()
    { return Input.GetAxis(HORIZONTAL); }
}
