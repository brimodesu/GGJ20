using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public float live = 0.5f;
    public Image lifeImage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lifeImage.fillAmount = live;
    }

    public void IncreaseLive(float live_points)
    {
        live += live_points;
        lifeImage.fillAmount = live;
        if (live>= 100)
        {
           //Win Game 
        }

    }

    public void ReduceLive(float damage)
    {
        live -= damage;
        lifeImage.fillAmount = live;
        if (live <= 49)
        {
            lifeImage.color = Color.red;
        }

        if (live <= 0)
        {
            //GameOver
        }
    }
}
