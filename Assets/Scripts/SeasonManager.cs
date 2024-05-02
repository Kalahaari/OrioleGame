using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager instance { get; private set; }
    public delegate void OnSeasonChange();
    [SerializeField] GameObject PP1, PP2, PP3;
    GameObject[] PPArray;
    public static OnSeasonChange onSeasonChange;
    [SerializeField] float SeasonTimer;
    [SerializeField] GameObject[] successScreens;
    [SerializeField] GameObject[] failScreens;
    public int CurrentSeason;
    public float CurrentTimer;
    // Start is called before the first frame update
    void Awake()
    {
        PPArray = new GameObject[] { PP1, PP2, PP3 };
        CurrentTimer = SeasonTimer;
        instance = this;
        CurrentSeason = 1;
        PPArray[1].SetActive(false);
        PPArray[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer <= 0)
        {
            failScreens[CurrentSeason - 1].SetActive(true);
            failScreens[CurrentSeason - 1].GetComponent<CloseMe>().FreezeTime();
            //NextSeason(CurrentSeason);
        }

    }

    public void NextSeason(int seasonNumber)
    {
        successScreens[seasonNumber - 1].SetActive(true);
        successScreens[seasonNumber - 1].GetComponent<CloseMe>().FreezeTime();
        CurrentSeason++;
        CurrentTimer = SeasonTimer;
        onSeasonChange?.Invoke();
        //Debug.Log("timerover")
        PPArray[seasonNumber].SetActive(true);
        PPArray[seasonNumber - 1].SetActive(false);
    }

}
