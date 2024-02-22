using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float tiltAmount;

    [SerializeField]
    GameObject wing1, wing2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Rotate(Vector3 movementValue)
    {
        if (movementValue.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementValue);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    public void TrailsOn()
    {
        wing1.GetComponent<TrailRenderer>().emitting = true;
        wing2.GetComponent<TrailRenderer>().emitting = true;
    }

    public void TrailsOff()
    {
        wing1.GetComponent<TrailRenderer>().emitting = false;
        wing2.GetComponent<TrailRenderer>().emitting = false;
    }

    
    public void TurnFlight(int data)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, tiltAmount * data);
    }
}
