using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorComponentesScript : MonoBehaviour
{
    public GameObject[] componentes;
    public float tiempo = 1f;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in componentes)
        {
            obj.GetComponent<ComponenteScript>().generador = this.gameObject;
        }
        Generar();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        //Se activa el primer objeto de la lista y se auto invoca cada cierto tiempo
        /*while (componentes[index].activeSelf == true)
        {
            index++;
            if (index == componentes.Length)
            {
                index = 0;
            }
        }*/
        Debug.Log(componentes[index].activeSelf.ToString());
        componentes[index].GetComponent<ComponenteScript>().Valorizar();
        componentes[index].SetActive(true);
        index++;
        if (index == componentes.Length)
        {
            index = 0;
        }
        Invoke("Generar", tiempo);
    }
}
