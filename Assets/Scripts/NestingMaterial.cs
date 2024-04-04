using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestingMaterial : MonoBehaviour
{
    SphereCollider col;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    public void PickedUp()
    {
        col.enabled = false;
        rb.isKinematic = true;
    }

    public void Drop()
    {
        col.enabled = true;
    }
}
