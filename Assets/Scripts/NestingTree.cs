using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestingTree : MonoBehaviour
{
    [SerializeField] GameObject triggerVolume;
    [SerializeField] GameObject NestingUIPrefab;
    [SerializeField] GameObject NestIndicator;

    GameObject LocalNestingUI;

    public int NestCompletionAmount;
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
        Debug.Log("entertree");
        if (other.gameObject.CompareTag("Player"))
        {
            LocalNestingUI.SetActive(true);
            NestIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exittree");
        if (other.gameObject.CompareTag("Player"))
        {
            LocalNestingUI.SetActive(false);
            NestIndicator.SetActive(false);
        }
    }
}
