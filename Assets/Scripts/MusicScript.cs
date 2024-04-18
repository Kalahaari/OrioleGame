using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clipsArray;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playMusicCoroutine());
    }

    
    IEnumerator playMusicCoroutine()
    {
        yield return null;

        for (int i = 0; i < clipsArray.Length; i++)
        {
            audioSource.clip = clipsArray[i];
            audioSource.Play();

            while (audioSource.isPlaying)
            {
                yield return null;
            }
        }
    }
}
