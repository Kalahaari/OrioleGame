using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        Debug.Log("Picked Up Food Item");
    }

    public void Eat()
    {
        Debug.Log("Ate Food");
        //add to hunger bar
        //destroy food object
    }
}
