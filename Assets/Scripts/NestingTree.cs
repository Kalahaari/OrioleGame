using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestingTree : MonoBehaviour
{
    [SerializeField] GameObject triggerVolume;
    [SerializeField] GameObject NestingUIPrefab;
    [SerializeField] GameObject NestIndicator;

    GameObject LocalNestingUI;

    public float NestCompletionAmount;
    // Start is called before the first frame update
    void Start()
    {
        NestCompletionAmount = 0;
        LocalNestingUI = Instantiate(NestingUIPrefab);
        LocalNestingUI.GetComponentInChildren<NestingUI>().tree = gameObject;
        LocalNestingUI.SetActive(false);
        NestIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            LocalNestingUI.SetActive(true);
            NestIndicator.SetActive(true);
            Debug.Log("entertree");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("exittree");
            //LocalNestingUI.SetActive(false);
            //NestIndicator.SetActive(false);
        }
    }
}
