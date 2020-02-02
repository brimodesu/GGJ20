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
    private bool picked = false;
    private GameObject interactedObj;

    public Vector3 startPos;

    public GameObject model;
    
    public Transform pickedItemPos;
    private void Start()
    {
        Debug.Log("New Player created.");
        //startPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void regresarComponente()
    {
        interactedObj.GetComponent<ComponenteScript>().regresar();
    }

    public void OnJump()
    {
        if(picked)
        {
            interactedObj.transform.parent = null;
            //interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().isKinematic = false;
            interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().useGravity = true;
            canDrop = false;
            picked = false; 
            if (canDrop)
            {
                regresarComponente();
            }
            else
            {
                Invoke("regresarComponente", 5f);   
            }

            interactedObj = null;
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
        if (canInteract)
        {
            interactedObj.GetComponent<ComponenteScript>().velocidad = 0f;
            //interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().isKinematic = true;
            interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().useGravity = false;
            interactedObj.transform.parent = pickedItemPos.transform;
            interactedObj.transform.position = pickedItemPos.position;
            canInteract = false;
            picked = true;
        }
        
    }

    public void OnDrop()
    {
        interactedObj.transform.parent = null;
        interactedObj.GetComponent<ComponenteScript>().gameObject.GetComponent<Rigidbody>().useGravity = true;
        canDrop = false;
       
        interactedObj = null;
    }

    public void OnMovement(InputValue value)
    {
        /// Debug.Log("Value: " + value);
        i_movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        model.transform.eulerAngles = new Vector3( 0, (Mathf.Atan2( i_movement.y , i_movement.x * -1f) * 180f / Mathf.PI) , 0 );
    }

    public void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y);
       // Debug.Log(i_movement.x);
        transform.Translate(movement  * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Material") && picked == false)
        {
            canInteract = true;
            interactedObj = other.gameObject;
        }

        if (other.CompareTag("ComponentBuilder") && picked == true)
        {
            canDrop = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Material") && picked == false)
        {
            canInteract = false;
            interactedObj = null;
        }

        if (other.CompareTag("ComponentBuilder") && picked == true)
        {
            canDrop = false;
        }
    }

    public void resetPost()
    {
        transform.position = startPos;
    }

    private void OnCollisionEnter(Collision other)
    {
     
    }
}