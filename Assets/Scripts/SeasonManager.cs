using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager instance { get; private set; }
    public delegate void OnSeasonChange();
    public static OnSeasonChange onSeasonChange;
    [SerializeField] float SeasonTimer;
    public int CurrentSeason;
    float CurrentTimer;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentTimer = SeasonTimer;
        instance = this;
        CurrentSeason = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTimer -= Time.deltaTime;
        if(CurrentTimer <= 0)
        {
            NextSeason();
        }

    }

    void NextSeason()
    {
        CurrentSeason++;
        CurrentTimer = SeasonTimer;
        onSeasonChange?.Invoke();
        Debug.Log("timerover");
    }

}
