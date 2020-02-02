using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public GameObject[] Players;

    private int PlayerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        var player = Instantiate(Players[GameObject.Find("GameManager")
            .GetComponent<GameManager>().pos_assigned
        ]);
    }

    // Update is called once per frame
    void Update()
    {
    }

        public void OnPlayerJoined()
        {
            Players[PlayerCount].SetActive(true);
            PlayerCount++;
        }
}