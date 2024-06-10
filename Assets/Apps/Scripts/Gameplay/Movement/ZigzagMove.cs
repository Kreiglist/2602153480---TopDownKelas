using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum MoveDirection
{
    Left = -1, Right = 1
}

public class ZigzagMove : MonoBehaviour
{
    private MoveDirection moveDirection;

    [SerializeField] private float offset;
    [SerializeField] private float horizontalSpeed;
    private IMovement movement;
    private Vector2 direction;
    private Vector3 origin;

    private void Awake()
    {
        movement = GetComponent<IMovement>();
        moveDirection = MoveDirection.Left;

        direction = new Vector2();
    }

    private void Start()
    {
        direction.y = -1f;
        origin = transform.position;
    }

    private void Update()
    {
        if (IsTouchingLeftSide())
        {
            moveDirection = MoveDirection.Right;
        }
        if (IsTouchingRightSide())
        {
            moveDirection = MoveDirection.Left;
        }

        UpdatePosition();
    }

    private bool IsTouchingRightSide()
    {
        return transform.position.x > origin.x + offset;
    }

    private bool IsTouchingLeftSide()
    {
        return transform.position.x < origin.x - offset;
    }

    private void UpdatePosition()
    {
        direction.x = (float)moveDirection;
        movement.SetDirection(direction.x * horizontalSpeed, direction.y);
    }
}
