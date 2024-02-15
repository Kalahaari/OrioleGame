using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Movement Variables")] 

    [SerializeField] float moveSpeed;
    [SerializeField] float groundDrag;
    [SerializeField] float airDrag;
    [SerializeField] float flapDrag;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityMultiplier;
    [SerializeField] float glideGravityMultiplier;
    [SerializeField] float glideSpeed;
    [SerializeField] float groundCheckRadius;
    [SerializeField] float turnSpeed;
    [SerializeField] float turnRadius;
    public bool airborne;
    bool dragLocked;
    bool FlyHeld;
    Vector3 movementValue;
    #endregion

    [Header("References")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] Camera cam;
    Rigidbody rb;

    #region Model
    [SerializeField] GameObject model;
    modelScript ms;
    #endregion

    #region State Machine Declarations
    private enum State
    {
        Run,
        Glide,
        Flap,
    }

    private State state;
    #endregion

    LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        ms = model.GetComponent<modelScript>();
        rb = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("ground");

        dragLocked = false;
        state = State.Run;
    }

    // Update is called once per frame
    void Update()
    {
        #region State Machine
        switch (state)
        {
            case State.Run:
                Run();
                break;

            case State.Glide:
                Glide();
                break;

            case State.Flap:
                Flap();
                break;
        }
        #endregion

        GroundCheck();

        if (!airborne) state = State.Run;

        Gravity(state == State.Glide);
        Debug.Log(state);
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Run:
                rb.AddForce(movementValue * moveSpeed, ForceMode.Force);
                break;
            case State.Glide:
                rb.AddForce(transform.forward * glideSpeed, ForceMode.Force);
                if(movementValue.x > 0)
                {
                    rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x + turnRadius, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), turnSpeed));
                }
                break;

            case State.Flap:
                rb.AddForce(movementValue * moveSpeed, ForceMode.Force);
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);

        if (airborne)
        {
            if(movementValue.z > 0)
            {
                state = State.Glide;
            }
            else
            {
                state = State.Flap;
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
        }
    }

    #region Physics Methods
    void ChangeDrag(float data)
    {
        if (!dragLocked)
        {
            rb.drag = data;
        }

    }
    void Gravity(bool gliding)
    {
        rb.AddForce(Physics.gravity * (gliding ? glideGravityMultiplier : gravityMultiplier), ForceMode.Acceleration);
    }
    void GroundCheck()
    {
        airborne = true;

        Collider[] colliders = Physics.OverlapSphere(groundCheck.transform.position, groundCheckRadius, groundMask);

        if (colliders.Length > 0)
        {
            airborne = false;
        }
    }
    void RotateMovementToCamera()
    {
        movementValue = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * movementValue;
    }
    #endregion

    void Glide()
    {
        ChangeDrag(airDrag);
        ms.anim.Play("Glide");
        ms.TrailsOn();
        turnRadius = (movementValue.x > 0) ? turnRadius : -turnRadius;
    }

    void Run()
    {
        //RotateMovementToCamera();
        ms.Rotate(movementValue);

        ChangeDrag(groundDrag);
        ms.anim.Play("Run");
        ms.TrailsOff();
    }

    void Flap()
    {
        RotateMovementToCamera();
        ms.Rotate(movementValue);
        ms.TrailsOff();
        ChangeDrag(flapDrag);
    }


    /*
    switch the running code so that instead of leaving the character unrotated and just rotating the model, we are actually rotating the model of the character, because when you jump and start flying, it needs to happen in the same rotation that you already had. 
    */
}
