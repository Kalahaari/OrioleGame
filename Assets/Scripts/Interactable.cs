using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public UnityEvent InteractEvent;

    // Start is called before the first frame update
    void Start()
    {
        //InteractEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Invoked");
        //InteractEvent.Invoke();

        //Invoke(nameof(InteractEvent), 1f);
        InteractEvent?.Invoke();
    }
}
