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
    [SerializeField] float turnRadiusAmount;
    [SerializeField] float rotateSpeed;
    public bool airborne;
    bool dragLocked;
    public bool glideHeld;
    float turnRadius;
    Vector3 movementValue;
    #endregion

    [Header("References")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] Camera cam;
    [SerializeField] PlayerData pd;
    AudioSource audioSource;
    Rigidbody rb;

    [Header("Energy Variables")]
    [SerializeField] int flapEnergy;
    [SerializeField] float EnergyDecreaseInterval;
    [SerializeField] float EnergyDecreaseAmount;

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
        audioSource = GetComponent<AudioSource>();
        groundMask = LayerMask.GetMask("ground");

        dragLocked = false;
        state = State.Run;

        pd.SetEnergy(100);
        StartCoroutine(EnergyCoroutine());
    }

    void Update()
    {
        //Debug.Log(movementValue);

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

        //glideHeld = (movementValue != Vector3.zero) ? true : false;
        if(movementValue != Vector3.zero)
        {
            glideHeld = true;
        } else
        {
            glideHeld = false;
        }
        //glideHeld = true;


        if (airborne)
        {
            if (glideHeld)
            {
                state = State.Glide;
            }
            else
            {
                state = State.Flap;
            }
        }
        else
        {
            state = State.Run;
        }

        //print(state);

    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Run:
                rb.AddForce(movementValue * moveSpeed, ForceMode.Force);
                RotatePlayer();
                break;

            case State.Glide:
                rb.AddForce(transform.forward * glideSpeed, ForceMode.Force);
                RotatePlayer();
                TiltPlayer();
                break;

            case State.Flap:
                break;

        }
        Gravity(glideHeld);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        RotateMovementToCamera();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
            pd.ChangeEnergy(-flapEnergy / 2);
            audioSource.Play();
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
        //rb.AddForce(Physics.gravity * (gliding ? glideGravityMultiplier : gravityMultiplier), ForceMode.Acceleration);
        if (gliding)
        {
            rb.AddForce(Physics.gravity * glideGravityMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        }
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
        
    }

    void Run()
    {
        //rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        

        ChangeDrag(groundDrag);
        ms.anim.Play("Run");
        ms.TrailsOff();
    }

    void Flap()
    {

        ms.TrailsOff();
        ChangeDrag(flapDrag);
    }

    void RotatePlayer()
    {
        if (movementValue.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementValue);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed));
    }

    void TiltPlayer()
    {
        //Debug.Log(rb.angularVelocity);
        //if(move)
    }

    IEnumerator EnergyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnergyDecreaseInterval);
            pd.ChangeEnergy(-EnergyDecreaseAmount);
            //Debug.Log(pd.playerEnergy);
            if(pd.playerEnergy > 100)
            {
                pd.SetEnergy(100);
            }
        }
    }
}
