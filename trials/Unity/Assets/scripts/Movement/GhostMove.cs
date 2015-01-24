using UnityEngine;
using System.Collections;
using System;

public class GhostMove : MoveByAnimator
{
    protected override bool canMove
    {
        get 
        {
            return (Vertical != 0 ^ Horizontal != 0);
        }
    }

    protected override float Vertical
    {
        get
        {
            return GetMovementKey(KeyCode.UpArrow, KeyCode.DownArrow);
        }
    }

    protected override float Horizontal
    {
        get
        {
            return GetMovementKey(KeyCode.RightArrow, KeyCode.LeftArrow);
        }
    }

    private float GetMovementKey(KeyCode plus, KeyCode minus)
    {
        Func<KeyCode, bool> get = Input.GetKey;

        if (get(plus))
            return 1;
        else if (get(minus))
            return -1;

        return 0;
    }
}
