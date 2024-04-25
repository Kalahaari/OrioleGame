using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMusicScript : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;
    private int currentClipIndex = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextClip();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    private void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Count)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;
        }
        else
        {
            Debug.Log("All music played");
        }
    }
}
