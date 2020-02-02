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
                _LevelController.ReduceLive(other.gameObject.GetComponent<ComponentBuilderController>()
                    .damage_if_incomplete);
            }
            else
            {
                _LevelController.IncreaseLive(other.gameObject.GetComponent<ComponentBuilderController>()
                    .life_to_increase);
            }
        }
        other.transform.parent.GetComponent<ComponenteScript>().regresar();
    }
}