using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool CheckMoveInput()
    {
        if(Input.GetAxis(GlobalStrings.HORIZONTAL) != 0)
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
    public static bool CheckPushInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
            return true;
        return false;
    }
    public static bool CheckBackInput()
    {
        if(Input.GetKeyDown(KeyCode.U))
            return true;
        return false;
    }
    public static float GetHoriontalValue()
    { return Input.GetAxis(GlobalStrings.HORIZONTAL); }
}
