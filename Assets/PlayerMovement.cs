using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float groundDrag;

    [SerializeField]
    float airDrag;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float gravityMultiplier;

    [SerializeField]
    float glideSpeed;

    [SerializeField]
    GameObject model;

    Rigidbody rb;
    modelScript ms;

    bool dragLocked;

    bool FlyHeld;
    private enum State
    {
        Run,
        Fly,
    }

    private State state;

    Vector3 movementValue;

    public bool airborne;

    [SerializeField]
    GameObject groundCheck;

    [SerializeField]
    float groundCheckRadius;

    [SerializeField]
    Camera cam;

    LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Run;
        rb = GetComponent<Rigidbody>();

        dragLocked = false;
        groundMask = LayerMask.GetMask("ground");

        ms = model.GetComponent<modelScript>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Run:
                ChangeDrag(groundDrag);
                ms.anim.Play("Run");
                ms.TrailsOff();
                rb.AddForce(movementValue * moveSpeed, ForceMode.Force);
                //Debug.Log(rb.velocity);
                //rb.velocity = new Vector3(movementValue.x * moveSpeed, rb.velocity.y, movementValue.z * moveSpeed);

                break;
            case State.Fly:
                ChangeDrag(airDrag);
                ms.anim.Play("Fly");
                ms.TrailsOn();
                rb.AddForce(movementValue * glideSpeed, ForceMode.Force);
                break;
        }

        airborne = true;

        Collider[] colliders = Physics.OverlapSphere(groundCheck.transform.position, groundCheckRadius, groundMask);

        if (colliders.Length > 0)
        {
            airborne = false;
            state = State.Run;
        } else
        {
            state = State.Fly;
        }

        Gravity();

        ms.Rotate(movementValue);

        if (FlyHeld)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    /*public void OnMove(InputValue value)
    {
        movementValue = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        movementValue = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * movementValue;
    }*/

    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        //Debug.Log(movementValue);
        //movementValue = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * movementValue;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("fly");
        if (context.performed)
        {
            FlyHeld = true;
            
        } else if (context.canceled)
        {
            FlyHeld = false;
        }
        
        
        //Debug.Log("jump");
        /*if (!airborne)
        {
            rb.position += new Vector3(0, 0);

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
        }*/
        
    }

    void ChangeDrag(float data)
    {
        if (!dragLocked)
        {
            rb.drag = data;
        }

    }
    void Gravity()
    {
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        //Debug.Log(Physics.gravity * gravityMultiplier);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Debug.Log("test");
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.CompareTag("Interactable"))
                {
                    //Debug.Log("caterpilar");
                    col.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }

        
    }
}
