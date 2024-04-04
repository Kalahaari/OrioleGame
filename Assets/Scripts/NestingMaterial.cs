using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestingMaterial : MonoBehaviour
{
    SphereCollider col;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PickedUp()
    {
        audioSource.PlayOneShot(audioClips[0]);
        col.enabled = false;
        rb.isKinematic = true;
    }

    public void Drop()
    {
        audioSource.PlayOneShot(audioClips[1]);
        col.enabled = true;
        rb.isKinematic = false;
    }
}
