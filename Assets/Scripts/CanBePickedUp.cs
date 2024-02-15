using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanBePickedUp : MonoBehaviour
{
    public UnityEvent PickUpEvent;
    
    public void PickUp()
    {
        //Debug.Log("Invoked");

        PickUpEvent?.Invoke();
    }
}
