using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    float rotateSpeed;

    [SerializeField]
    float turnRotationAmount;

    [SerializeField]
    GameObject wing1, wing2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void TurnFlight(bool rightTurn)
    {
        transform.Rotate(transform.forward, rightTurn ? turnRotationAmount : -turnRotationAmount);
    }
}
