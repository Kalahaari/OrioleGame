using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] PlayerData pd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //called when in range of the food and presses F
    public void Eat()
    {
        Debug.Log("Ate Food");
        //add to hunger bar
        Destroy(this.gameObject);
        pd.ChangeEnergy(5);
    }
}
