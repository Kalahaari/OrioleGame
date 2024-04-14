using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestingTree : MonoBehaviour
{
    [SerializeField] GameObject triggerVolume;
    [SerializeField] GameObject NestingUIPrefab;
    [SerializeField] GameObject NestIndicator;
    [SerializeField] AudioClip femaleBirdsong;
    [SerializeField] AudioClip maleBirdsong;
    AudioSource audioSource;

    [SerializeField] GameObject femaleBird;
    [SerializeField] GameObject femaleBirdLocation;

    GameObject LocalNestingUI;

    public float NestCompletionAmount;

    
    bool inTree;
    int numberOfSings;
    // Start is called before the first frame update
    void Start()
    {
        NestCompletionAmount = 0;
        LocalNestingUI = Instantiate(NestingUIPrefab);
        LocalNestingUI.GetComponentInChildren<NestingUI>().tree = gameObject;
        LocalNestingUI.SetActive(false);
        NestIndicator.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInteraction>().NestingTree = gameObject;
            LocalNestingUI.SetActive(true);
            NestIndicator.SetActive(true);
            inTree = true;
            Debug.Log("entertree");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInteraction>().NestingTree = null;
            Debug.Log("exittree");
            inTree = false;
            //LocalNestingUI.SetActive(false);
            //NestIndicator.SetActive(false);
        }
    }

    public void BirdSing()
    {
        if (inTree)
        {
            StartCoroutine(SingingEchoCoroutine());
            numberOfSings++;
        }
        
    }

    IEnumerator SingingEchoCoroutine()
    {
        yield return new WaitForSeconds(maleBirdsong.length);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(femaleBirdsong, numberOfSings + 1);
        yield return new WaitForSeconds(femaleBirdsong.length);
        if (numberOfSings >= 3)
        {
            Instantiate(femaleBird, femaleBirdLocation.transform.position, femaleBirdLocation.transform.rotation, femaleBirdLocation.transform);
            Debug.Log("next season");
        }
    }
    
}
