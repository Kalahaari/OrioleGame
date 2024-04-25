using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] PlayerData pd;
    [SerializeField] int Damage;


    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ouch window!");
            pd.ChangeEnergy(Damage);
        }
    }

}