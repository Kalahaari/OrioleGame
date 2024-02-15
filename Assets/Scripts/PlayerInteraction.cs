using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldFood = null; //food is not held at start
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*// Detect if 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Attempt to pick up food
            PickupFood();
        }

        // Detect if 'F' is pressed
        if (Input.GetKeyDown(KeyCode.F) && heldFood != null)
        {
            // Eat the food
            EatFood();
        }*/
    }

    void PickupFood()
    {
        // Implement logic to pick up food
        heldFood.GetComponent<FoodScript>().PickUp();
        //position food in birds mouth so it looks like its holding it
    }

    void EatFood()
    {
        // Call the Eat method on the food script
        heldFood.GetComponent<FoodScript>().Eat();
        Destroy(heldFood);
        heldFood = null;
    }

    public void OnFeed(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("feed");
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.CompareTag("Interactable"))
                {
                    //Debug.Log("caterpilar");
                    col.gameObject.GetComponent<Edible>().Eat();
                }
            }
        }
    }

    public void OnPickup(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("pickup");
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.CompareTag("Interactable"))
                {
                    //Debug.Log("caterpilar");
                    col.gameObject.GetComponent<CanBePickedUp>().PickUp();
                }
            }
        }

    }
}
