using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldFood; // Reference to the currently held food item
    [SerializeField] GameObject mouthPosition; // Assign this in the inspector to the player's mouth transform


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && heldFood != null)
        {
            //DropHeldItem();
        }
    }
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
            if (heldFood)
            {
                heldFood.transform.SetParent(null);
                heldFood = null;
            }
            else
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
                foreach (Collider col in hitColliders)
                {
                    if (col.gameObject.CompareTag("Interactable"))
                    {
                        heldFood = col.gameObject;
                        heldFood.transform.SetParent(mouthPosition.transform);
                        heldFood.transform.localPosition = Vector3.zero;
                        heldFood.transform.localRotation = Quaternion.identity;

                        //col.gameObject.transform.SetParent(mouthPosition.transform);
                        //col.transform.localPosition = Vector3.zero;
                        //col.transform.localRotation = Quaternion.identity;



                        /*GameObject item = col.gameObject;
                        CanBePickedUp pickUpComponent = item.GetComponent<CanBePickedUp>();
                        if (pickUpComponent != null)
                        {
                            pickUpComponent.PickUp();
                            if (heldFood != null)
                            {
                                // If already holding an item, drop it or destroy it
                                // Implement drop or destroy logic here
                            }
                            heldFood = item;
                            // Parent the item to the mouth position and reset its local position and rotation
                            item.transform.SetParent(mouthPosition);
                            item.transform.localPosition = Vector3.zero;
                            item.transform.localRotation = Quaternion.identity;
                        }*/

                    }
                }
            }
        }
    }

    void DropHeldItem()
    {
        if (heldFood != null)
        {
            // Detach the item from the player
            heldFood.transform.SetParent(null);

            // Optionally apply some physics to simulate dropping
            Rigidbody itemRigidbody = heldFood.GetComponent<Rigidbody>();
            if (itemRigidbody != null)
            {
                itemRigidbody.isKinematic = false; // Make sure the Rigidbody is not kinematic
                itemRigidbody.AddForce(transform.forward * 5, ForceMode.Impulse); // Apply a forward force
            }

            // Clear the reference to the held item
            heldFood = null;
        }
    }
}
