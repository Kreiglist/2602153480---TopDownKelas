using UnityEngine;

public class ForwardMove : MonoBehaviour
{
    private IMovement movement;

    private void Awake()
    {
        movement = GetComponent<IMovement>();
    }

    private void Start()
    {
        movement.SetDirection(0, -1);
    }
}
