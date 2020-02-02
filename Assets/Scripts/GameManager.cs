using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int pos_assigned = 0;

    public GameObject pnlGameOver, pnlCredits;
    void Start()
    {
        Players = new List<GameObject>();
    }
    

    public void AddPlayer(GameObject go)
    {
        Debug.Log("add player");
go.GetComponent<Movement>().startPos = positions[pos_assigned].position;
        go.transform.position = positions[pos_assigned].position;
        go.GetComponent<PlayerController>().EnablePlayer(pos_assigned);
        pos_assigned++;
        Players.Add(go);
    }
    
    public void ReloadGame()
    {
        SceneManager.LoadScene("bup2");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    public void ManagePanelVisibility(GameObject pnl)
    {
        pnl.SetActive(!pnl.active);
    }

    public void showGameOver()
    {
        ManagePanelVisibility(pnlGameOver);
        
    }
    public void showCredits()
    {
        ManagePanelVisibility(pnlCredits);
        
    }
}
