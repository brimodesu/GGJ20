using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class ComponentBuilderController : MonoBehaviour
{
    public  List<RequiredItem> required_items = new List<RequiredItem>();
    [SerializeField] private static float velocidad = 0.5f;

    public GameObject img;
    public Canvas Canvas;

    private void Start()
    {
        foreach (var requiredItem in required_items)
        {
            CreateRequiredItemIndicator(requiredItem);
        }
    }

    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals("Material"))
        {
            var ComponentP = other.gameObject.GetComponent<ComponenteScript>();
            Debug.Log(ComponentP.tipo);
            bool containsItem = required_items.Any(item => item.name == ComponentP.tipo.ToString());
            Debug.Log(containsItem);
            if (containsItem)
            {
                IEnumerable<RequiredItem> required_item = required_items.Where(item => item.name.Equals(ComponentP.tipo.ToString()));
               
                foreach (var item in required_item)
                {
                    item.image_obj.color =  new Color32(0,255,0,255);
                }
            }
        }
    }

    private int offset = 0;
    void CreateRequiredItemIndicator(RequiredItem requiredItem)
    {
        
        var createImage = Instantiate(img) as GameObject;
      
        createImage.transform.position = new  Vector3(createImage.transform.position.x + offset ,createImage.transform.position.y,0f);
        offset += 30;
        createImage.transform.SetParent(Canvas.transform, false);
        requiredItem.image_obj = createImage.GetComponent<Image>();

    }
}
