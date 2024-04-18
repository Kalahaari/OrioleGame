using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChange : MonoBehaviour
{
    int SeasonTimer;
    [SerializeField] Material[] material;
    Material[] tempArray;
    private MeshRenderer rend;
    [SerializeField] Material barkMat;
    
    void Start()
    {
        updateArray(material[0]);
        //SeasonTimer = SeasonTimerMax;
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.materials = tempArray;
        //StartCoroutine(CountDown());
    }

    void updateArray(Material data)
    {
        tempArray = new Material[] { data, barkMat};
    }
    
    private void OnEnable()
    {
        SeasonManager.onSeasonChange += MaterialChange;
    }

    private void OnDisable()
    {
        SeasonManager.onSeasonChange -= MaterialChange;
    }

    void MaterialChange()
    {
        updateArray(material[SeasonManager.instance.CurrentSeason - 1]);
        rend.materials = tempArray;
        Debug.Log("materialchange");
    }

    void Update()
    {
        
    }
    //set limit for loop also set int
    //make sure the timer happens twice
    /*private IEnumerator CountDown()
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
    }*/
}
