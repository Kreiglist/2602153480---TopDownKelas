using UnityEngine;

public interface IMovement
{
    void SetDirection(float x, float y);
    Vector2 GetDirection();
}