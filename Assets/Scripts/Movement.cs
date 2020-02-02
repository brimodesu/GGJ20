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

    private Vector3 startPos;

    public GameObject model;
    
    public Transform pickedItemPos;
    private void Start()
    {
        Debug.Log("New Player created.");
        startPos = transform.position;
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
            canInteract = false;
        }

        if (canDrop)
        {
            interactedObj.transform.parent = null;
            interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
            canDrop = false;
            interactedObj.GetComponent<ComponenteScript>().regresar();
            interactedObj = null;
        }
    }

    public void OnMovement(InputValue value)
    {
        /// Debug.Log("Value: " + value);
        i_movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (i_movement.x > 0)
        {
            model.transform.rotation = Quaternion.Euler(0,180.0f  ,0);
        }
        else if(i_movement.x < 0)
        {
            model.transform.rotation = Quaternion.Euler(0,360.0f  ,0);

        }
        else
        {
            model.transform.rotation = Quaternion.Euler(0,90.0f  ,0);
        }
    }

    public void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * movementSpeed * Time.deltaTime;
        Debug.Log(i_movement.x);

  




        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Material") && interactedObj == null)
        {
            canInteract = true;
            interactedObj = other.gameObject;
        }

        if (other.gameObject.tag.Equals("CintaP") && interactedObj != null)
        {
            
            canDrop = true;
            
        }

        if (other.gameObject.tag.Equals("Killer"))
        {
            transform.position = startPos;
        }
    }
}