using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] float timeToChangeDirection;
    Rigidbody rb;
    [SerializeField] float movespeed;

    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        timeToChangeDirection -= Time.deltaTime;
        rb.velocity = new Vector3(transform.forward.x * movespeed, rb.velocity.y, transform.forward.z * movespeed);

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }
    }


    private void ChangeDirection()
    {
        float angle = Random.Range(0f, 360f);
        //Quaternion quat = Quaternion.AngleAxis(angle, Vector3.up);
        rb.MoveRotation(Quaternion.Euler(0, angle, 0));
        /*Vector3 newUp = quat * Vector3.forward;
        newUp.z = 0;
        newUp.Normalize();
        transform.up = newUp;*/
        timeToChangeDirection = Random.Range(1f, 3f);
    }
}