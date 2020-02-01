using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player
{
    private int key = 0;
    private GameObject go;
    private Transform position;
    
}

public class GameManager : MonoBehaviour
{
    public List<GameObject> Players;

    public Transform[] positions;
    private int pos_assigned = 0;
    void Start()
    {
        Players = new List<GameObject>();
    }
    

    public void AddPlayer(GameObject go)
    {
        Debug.Log("add player");

        go.transform.position = positions[pos_assigned].position;
        pos_assigned++;
        Players.Add(go);
    }
}
