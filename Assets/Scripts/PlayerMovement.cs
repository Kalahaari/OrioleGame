using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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
    bool glideHeld;
    float turnRadius;
    Vector3 movementValue;
    #endregion

    [Header("References")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] Camera cam;
    [SerializeField] PlayerData pd;
    [SerializeField] TextMeshProUGUI energyPlaceholder;
    AudioSource audioSource;
    Rigidbody rb;

    [Header("Energy Variables")]
    [SerializeField] int flapEnergy;
    [SerializeField] float EnergyDecreaseInterval;
    [SerializeField] int EnergyDecreaseAmount;

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

        glideHeld = (movementValue.z > 0) ? true : false;
        

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
        } else
        {
                state = State.Run;
        }

        Gravity(state == State.Glide);

        energyPlaceholder.text = ("Energy: " + pd.playerEnergy);
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
                
                rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + turnRadius, transform.rotation.eulerAngles.z), turnSpeed));
                
                break;

            case State.Flap:
                //rb.AddForce(movementValue * moveSpeed, ForceMode.Force);
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);

        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
            pd.ChangeEnergy(-flapEnergy);
            audioSource.Play();
            //Debug.Log(pd.playerEnergy);
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

        if(movementValue.x > 0)
        {
            turnRadius = turnRadiusAmount;
            ms.TurnFlight(-1);
        } else if(movementValue.x < 0)
        {
            turnRadius = -turnRadiusAmount;
            ms.TurnFlight(1);
        } else
        {
            turnRadius = 0;
            ms.TurnFlight(0);
        }
        
        //Debug.Log(turnRadius);
        
        //ms.TurnFlight(turnRadius > 0);
    }

    void Run()
    {
        //RotateMovementToCamera();
        //ms.Rotate(movementValue);
        rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        RotatePlayer();

        ChangeDrag(groundDrag);
        ms.anim.Play("Run");
        ms.TrailsOff();
    }

    void Flap()
    {
        //RotateMovementToCamera();
        //ms.Rotate(movementValue);
        
        ms.TrailsOff();
        ChangeDrag(flapDrag);
    }

    void RotatePlayer()
    {
        if (movementValue.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementValue);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed));
    }

    IEnumerator EnergyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnergyDecreaseInterval);
            pd.ChangeEnergy(-EnergyDecreaseAmount);
            //Debug.Log(pd.playerEnergy);
        }
    }
}
