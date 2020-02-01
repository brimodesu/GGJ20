using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorComponentesScript : MonoBehaviour
{
    public Object[] componentes;
    public float tiempo = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Generar();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        //Se genera un nuevo objeto, y se vuelve a invocar a si mismo el metodo cada cierto tiempo
        Instantiate(componentes[Random.Range(0, componentes.Length)], this.transform.position, transform.rotation);
        Invoke("Generar", tiempo);
    }
}
