using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sing : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSinging()
    {
        audioSource.Play();

        Debug.Log("singing");
    }

    public void ShowImage()
    {
        image.SetActive(true);
    }

}
