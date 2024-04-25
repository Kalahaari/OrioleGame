using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTrees : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit smth");
        if (collision.gameObject.CompareTag("tree"))
        {
            rb.isKinematic = true;
        }
    }
}
