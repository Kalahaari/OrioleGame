using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whole Level = 10 minutes, Season = 10/3 min

When season changes,

-Goal changes.

1 = Mate

2 = Nest

3 = eat enough to fill expanded energy bar

-2D art on Buildings changes

-Materials on Trees changes

sound effect(?) changes
*/

public class SeasonChange : MonoBehaviour
{
    [SerializeField] int SeasonTimerMax;
    int SeasonTimer;
    [SerializeField] Material[] material;
    Material[] tempArray;
    private Renderer rend;
    [SerializeField] Material barkMat;
    [SerializeField] int x = 0;


    
    void Awake()
    {
        updateArray(material[0]);
        SeasonTimer = SeasonTimerMax;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.materials = tempArray;
        StartCoroutine(CountDown());
    }

    void updateArray(Material data)
    {
        tempArray = new Material[] {barkMat, data};
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
                //rend.sharedMaterial = material[x + 1];
                updateArray(material[x + 1]);
                rend.materials = tempArray;
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
