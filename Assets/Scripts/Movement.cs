using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;

    private Vector2 i_movement;



    private void Update()
    {
        Move();
    }

    public void OnJump()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
    }

    public void OnMovement(InputValue value)
    {
        Debug.Log("Value: " + value);
       i_movement = value.Get<Vector2>();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0,i_movement.y) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}