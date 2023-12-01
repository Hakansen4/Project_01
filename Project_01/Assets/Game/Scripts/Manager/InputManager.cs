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
    public static float GetHoriontalValue()
    { return Input.GetAxis(HORIZONTAL); }
}
