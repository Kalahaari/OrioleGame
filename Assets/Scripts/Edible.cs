using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Edible : MonoBehaviour
{
    public UnityEvent EatEvent;

    public void Eat()
    {
        //Debug.Log("Invoked");

        EatEvent?.Invoke();
    }
}
