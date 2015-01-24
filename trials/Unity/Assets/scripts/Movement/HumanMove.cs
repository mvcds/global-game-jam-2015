using UnityEngine;
using System.Collections;

public class HumanMove : MoveByAnimator
{
    [SerializeField]
    private HumanTarget target;

    protected override bool canMove
    {
        get
        {
            return true;
        }
    }

    protected override float Vertical
    {
        get 
        {
            return 0;
        }
    }

    protected override float Horizontal
    {
        get
        {
            return 1;
        }
    }

    //protected override void Move()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    //}

    //protected void Turn(float h, float v)
    //{
    //    if (target.)
    //    //transform.LookAt(target.transform);
    //}
}
