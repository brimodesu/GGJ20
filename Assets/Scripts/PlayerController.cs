using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager")
            .GetComponent<GameManager>()
            .AddPlayer(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("hola");
    }
}