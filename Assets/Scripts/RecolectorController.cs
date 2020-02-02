using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectorController : MonoBehaviour
{
    public LevelController _LevelController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ComponentBuilder"))
        {
            Debug.Log(other.gameObject.GetComponent<ComponentBuilderController>().isCompleted());
            if (!other.gameObject.GetComponent<ComponentBuilderController>().isCompleted())
            {
                _LevelController.ReduceLive(0.01f);
            }
        }
    }

   
}
