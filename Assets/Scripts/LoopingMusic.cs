using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingMusic : MonoBehaviour
{
   
    public int SeasonNumber;
     [Header("Each Season gets 3 loops")]
    public List<AudioClip> audioClips_1;
    public List<AudioClip> audioClips_2;
    public List<AudioClip> audioClips_3;
    
     [Header("Loop 2 starts X seconds after loop ")]
    public int delayBeforeSecondClip;
    public int delateBeforeThirdClip;
    
    public AudioSource myAudioSource_1;
    public AudioSource myAudioSource_2;
    public AudioSource myAudioSource_3;
    
    private List<AudioClip> CurrentSeasonsClips;

    private bool Season1Started;
    private bool Season2Started;
    private bool Season3Started;


    // Want to play 3 audio clips but delaye starting them so they do not all stop at same time
    // each sudio clip will loop
    // When season changes, then a different three sudio clips will play


    // Start is called before the first frame update
    void Start()
    {
        // // Playe all three loops right away
        // myAudioSource_1.PlayOneShot(audioClips_1[0]);
        // myAudioSource_2.PlayOneShot(audioClips_2[0]);
        // myAudioSource_3.PlayOneShot(audioClips_3[0]);

    }

    // Update is called once per frame
    void Update()
    {

        if (SeasonNumber == 1 && Season1Started == false)
        {
            // Assign the listofClips according to the season number
            CurrentSeasonsClips = audioClips_1;


            StartCoroutine(PlaySeasonMusic());

            Season1Started = true;
        }

        if (SeasonNumber == 2 && Season2Started == false)
        {
            
            // Assign the listofClips according to the season number
            CurrentSeasonsClips = audioClips_2;

            StartCoroutine(PlaySeasonMusic());

            Season2Started = true;
        }   

        if (SeasonNumber == 3 && Season3Started == false)
        {
            
            // Assign the listofClips according to the season number
            CurrentSeasonsClips = audioClips_2;

            StartCoroutine(PlaySeasonMusic());

            Season3Started = true;
        } 



    }


    public IEnumerator PlaySeasonMusic()
    {
        
        // Stop the first loop 
        myAudioSource_1.Stop();

        // Play the first loop and play the next two loops after their delayseconds
        myAudioSource_1.clip = CurrentSeasonsClips[0];
        myAudioSource_1.Play();

        // Stop the second loop 
        myAudioSource_2.Stop();

        yield return new WaitForSeconds(delayBeforeSecondClip);
        myAudioSource_2.clip = CurrentSeasonsClips[1];
        myAudioSource_2.Play();

        // Stop the third loop 
        myAudioSource_1.Stop();

        yield return new WaitForSeconds(delateBeforeThirdClip);
        myAudioSource_3.clip = CurrentSeasonsClips[2];
        myAudioSource_3.Play();
    }

}
