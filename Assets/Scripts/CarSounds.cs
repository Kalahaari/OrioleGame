using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{

    public AudioClip carhonk;
    [SerializeField] AudioSource aud;
    

// Start is called before the first frame update
    void Start()
    {
      aud = GetComponent<AudioSource>();  
      StartCoroutine(Honk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Honk()
    {
        yield return new WaitForSeconds(10);
        aud.PlayOneShot(carhonk);
        yield return new WaitForSeconds(5);
        StartCoroutine(Honk());
    }
}
