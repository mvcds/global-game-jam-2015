using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public abstract class MoveByAnimator : MonoBehaviour
{
    protected enum Direction
    {
        South = 0,
        Left = 1,
        Right = 2,
        North = 3
    }

    private Animator animator;

    [SerializeField]
    protected float speed = 1;

    protected Direction MyDirection
    {
        get;
        private set;
    }

    protected abstract bool canMove { get; }

    protected abstract float Vertical { get; }

    protected abstract float Horizontal { get; }

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        Direction? MyDirection = (Direction)animator.GetInteger("Direction");
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        if (canMove)
            Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        
        switch (MyDirection)
        {
            case Direction.South:
                pos += Vector3.down;
                break;
            case Direction.Left:
                pos += Vector3.left;
                break;
            case Direction.Right:
                pos += Vector3.right;
                break;
            case Direction.North:
                pos += Vector3.up;
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    private void Turn()
    {
        float v = Vertical, h = Horizontal;
        if (v > 0)
            MyDirection = Direction.North;
        else if (v < 0)
            MyDirection = Direction.South;
        else if (h > 0)
            MyDirection = Direction.Right;
        else if (h < 0)
            MyDirection = Direction.Left;

        animator.SetInteger("Direction", (int)MyDirection);
    }
}
