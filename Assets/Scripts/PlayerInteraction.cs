using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldFood; // Reference to the currently held food item
    [SerializeField] GameObject mouthPosition; // Assign this in the inspector to the player's mouth transform
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] PlayerData pd;
    [SerializeField] int singEnergyCost;
    AudioClip birdsong;
    AudioSource audioSource;

    public GameObject NestingTree;

    bool readyForSing;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        birdsong = audioClips[0];
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
                    col.gameObject.GetComponent<Edible>()?.Eat();
                    //audioSource.PlayOneShot(audioClips[0]);
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
                heldFood.GetComponent<CanBePickedUp>().Drop();
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

                        heldFood.gameObject.GetComponent<CanBePickedUp>().PickUp();

                    }
                }
            }
        }
    }

    public void OnSing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("sing");
            audioSource.PlayOneShot(audioClips[0]);
            pd.ChangeEnergy(-singEnergyCost);

            if (readyForSing)
            {
                StartCoroutine(SingCooldown());
            }

            if (NestingTree == null) return;
            NestingTree.GetComponent<NestingTree>().BirdSing();
        }
        


    }

    IEnumerator SingCooldown()
    {
        readyForSing = false;
        yield return new WaitForSeconds(birdsong.length);
        readyForSing = true;
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
