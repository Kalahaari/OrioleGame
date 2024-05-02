using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] SpiderMovement Spider;
    [SerializeField] PlayerData pd;
    [SerializeField] float DeletionTime;
    BoxCollider boxCollider;
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] AudioClip[] audioClips;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, DeletionTime);
        audioSource = GetComponent<AudioSource>();
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
        Spider.enabled = false;
        GetComponent<SpriteBillboard>().enabled = false;
        audioSource.PlayOneShot(audioClips[0]);
        
    }
    //called when in range of the food and presses F
    public void Eat()
    {
        Debug.Log("Ate Food");
        //add to hunger bar
        audioSource.PlayOneShot(audioClips[1]);
        Destroy(this.gameObject);
        pd.ChangeEnergy(10);
    }

    public void Drop()
    {
        boxCollider.enabled = true;
        rb.isKinematic = false;
        Spider.enabled = true;
        GetComponent<SpriteBillboard>().enabled = true;
        audioSource.PlayOneShot(audioClips[2]);
    }
}
