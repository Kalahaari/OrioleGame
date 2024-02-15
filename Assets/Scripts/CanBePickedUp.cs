using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanBePickedUp : MonoBehaviour
{
    public UnityEvent PickUpEvent;
    
    public void PickUp()
    {
        //move to have player hold item//stick to player
        //make held item = true

        Debug.Log("Item picked up");
        PickUpEvent?.Invoke();
    }
}
