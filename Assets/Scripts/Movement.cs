using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;

    private Vector2 i_movement;
    private bool canInteract = false;
    private bool canDrop = false;
    private GameObject interactedObj;

    public Transform pickedItemPos;
    private void Start()
    {
        Debug.Log("New Player created.");
    }

    private void Update()
    {
        Move();
    }

    public void OnJump()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
        if (canInteract)
        {
            interactedObj.GetComponent<ComponenteScript>().velocidad = 0f;
            interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
            interactedObj.transform.parent = this.gameObject.transform;
            interactedObj.transform.position = pickedItemPos.position;
        }

        if (canDrop)
        {
            interactedObj.transform.parent = null;
            interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void OnMovement(InputValue value)
    {
        /// Debug.Log("Value: " + value);
        i_movement = value.Get<Vector2>();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Material"))
        {
            canInteract = true;
            interactedObj = other.gameObject;
        }

        if (other.gameObject.tag.Equals("CintaP"))
        {
            canDrop = true;
        }
    }
}