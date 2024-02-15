using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject heldFood = null; //food is not held at start
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //this function just calls the eat funtiction
    public void OnFeed(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
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

    //this function just calls the pickup funtiction
    public void OnPickup(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.CompareTag("Interactable"))
                {
                    col.gameObject.GetComponent<CanBePickedUp>().PickUp();
                }
            }
        }

    }
}
