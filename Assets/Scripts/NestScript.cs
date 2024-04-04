using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestScript : MonoBehaviour
{
    [SerializeField] GameObject parentTree;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject nestModel;

    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    SpriteRenderer sr;
    NestingTree treeScript;
    // Start is called before the first frame update
    void Start()
    {
        treeScript = parentTree.GetComponent<NestingTree>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = sprites[0];
        nestModel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NestingMaterial>())
        {
            Destroy(other.gameObject);
            treeScript.NestCompletionAmount += 12.5f;
            if(treeScript.NestCompletionAmount >= 100)
            {
                sr.enabled = false;
                nestModel.SetActive(true);
                audioSource.PlayOneShot(audioClips[4]);
            }
            else if(treeScript.NestCompletionAmount >= 75)
            {
                sr.sprite = sprites[4];
                audioSource.PlayOneShot(audioClips[3]);
            }
            else if(treeScript.NestCompletionAmount >= 50)
            {
                sr.sprite = sprites[3];
                audioSource.PlayOneShot(audioClips[2]);
            }
            else if (treeScript.NestCompletionAmount >= 25)
            {
                sr.sprite = sprites[2];
                audioSource.PlayOneShot(audioClips[1]);
            }
            else if (treeScript.NestCompletionAmount >= 0)
            {
                sr.sprite = sprites[1];
                //audioSource.PlayOneShot(audioClips[0]);
            }
            
        }
    }
}
