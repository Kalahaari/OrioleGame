using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    
    [SerializeField] PlayerData pd;
    BoxCollider boxCollider;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hold()
    {
        Debug.Log("picked up");
        boxCollider.enabled = false;
        rb.isKinematic = true;
        GetComponent<SpriteBillboard>().enabled = false;
    }
    //called when in range of the food and presses F
    public void Eat()
    {
        Debug.Log("Ate Food");
        //add to hunger bar
        Destroy(this.gameObject);
        pd.ChangeEnergy(5);
    }

    public void Drop()
    {
        boxCollider.enabled = true;
        rb.isKinematic = false;
        GetComponent<SpriteBillboard>().enabled = true;
    }
}
