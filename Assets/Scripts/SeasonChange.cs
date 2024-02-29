using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whole Level = 10 minutes, Season = 10/3 min

When season changes,

-Goal changes.

1 = Mate

2 = Nest

-2D art on Buildings changes

-Materials on Trees changes

music, sound effect(?) changes
lighting, sun location changes
hook sounds
*/

public class SeasonChange : MonoBehaviour
{
    [SerializeField] int SeasonTimerMax;
    int SeasonTimer;
    [SerializeField] Material[] material;
    private Renderer rend;
    [SerializeField] int x = 0;

    void Awake()
    {
        SeasonTimer = SeasonTimerMax;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        StartCoroutine(CountDown());
    }


    void Update()
    {
        
    }
    //set limit for loop also set int
    //make sure the timer happens twice
    private IEnumerator CountDown()
    {
        while (true)
        {
            if(SeasonTimer == 0)
            {
                rend.sharedMaterial = material[x + 1];
                x++;
                SeasonTimer = SeasonTimerMax;
            }

            yield return new WaitForSeconds(1);
            if(SeasonTimer > 0)
            {
                SeasonTimer--;
            }
            if(x == 2)
            {
                break; 
            }
        }
    }
}
