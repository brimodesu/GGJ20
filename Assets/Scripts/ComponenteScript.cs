using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteScript : MonoBehaviour
{
    public float velocidadPublica = 2f;
    public float velocidad = 0f;
    public GameObject generador;
    public int tipo = 0;
    public GameObject[] modelos;
    private GameObject cinta = null;
    public
        // Start is called before the first frame update
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Cambia la velocidad del objeto en cada frame y la variable velocidad solo cambiara si el objeto toca la cinta, esto sin cambiar la velocidad
        // de 'y' pues funciona con la graveddd
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, velocidad);
    }

    //Reinicia el valor de el componente
    public void Valorizar()
    {
        this.modelos[tipo].SetActive(false);
        tipo = Random.Range(0, this.modelos.Length);
        this.modelos[tipo].SetActive(true);
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
        if (collision.collider.CompareTag("Cinta"))
        {
            if (cinta != null)
            {
                if (cinta != collision.gameObject)
                {
                    regresar();
                }
            }
            else
            {
                this.transform.position = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
                velocidad = velocidadPublica;
                cinta = collision.gameObject;
            }

            
        }
        else if (collision.collider.CompareTag("CintaP"))
        {
            if (cinta != null)
            {
                if (cinta != collision.gameObject)
                {
                    regresar();
                }
            }
            else
            {
                this.transform.position = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y, this.transform.position.z);
                // Game manager velocidad
                velocidad = velocidadPublica;
                cinta = collision.gameObject;
            }
        }
        else if (collision.collider.CompareTag("Basura"))
        {
            //Lo regresa a la posicion del generador
            regresar();
        }else if (collision.collider.CompareTag("Floor"))
        {
            Invoke("regresar", 5f);
        }
    }

    public void regresar()
    {
        this.transform.position = this.generador.transform.position;
        this.cinta = null;
        this.gameObject.SetActive(false);
    }

}
