using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteScript : MonoBehaviour
{
    public float velocidadPublica = -1f;
    private float velocidad = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cambia la velocidad del objeto en cada frame y la variable velocidad solo cambiara si el objeto toca la cinta, esto sin cambiar la velocidad
        // de 'y' pues funciona con la gravedad
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, velocidad);
    }
    //Detecta cualquier colision con la cinta
    private void OnCollisionEnter(Collision collision)
    {
        /*
         * En caso de que la colision sea con la cinta 
         * Cambiar la posición del objeto para hacer que el eje z coincida con la cinta independientemente de donde lo toque
         * Cambiar la velocidad en el eje al que se vaya a mover por una variable publica que esta en el game manager
         * En caso de que la colision sea con un destructor, si es el del final de la cinta sumara/restara puntos y si no solo lo destruye 
         */
        Debug.Log("colision");
        if (collision.collider.CompareTag("Cinta")) {
            Debug.Log("toco la cinta");
            this.transform.position = new Vector3(collision.gameObject.transform.position.x , this.transform.position.y, this.transform.position.z);
            velocidad = velocidadPublica;
            //Agrega este objeto a los objetos que tiene la cinta con la que colisiona
            collision.gameObject.GetComponent<CintaScript>().objetosActuales.Add(this);
        }else if (collision.collider.CompareTag("Meta")){
            //Suma/Resta y destruye
        }else if (collision.collider.CompareTag("Basura")){
            //Destruir
        }
    }

}
