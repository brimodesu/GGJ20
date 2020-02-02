using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public GameObject[] Players;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager")
            .GetComponent<GameManager>()
            .AddPlayer(this.gameObject);
        
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("hola");
    }

    public void EnablePlayer(int pos)
    {
        Debug.Log("Enabling player: " + pos);
        Players[pos].SetActive(true);
    }
}