using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorComponentesScript : MonoBehaviour
{
    public Object[] componentes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        Instantiate(componentes[Random.Range(0, componentes.Length - 1)], this.transform.position, transform.rotation);
    }
}
