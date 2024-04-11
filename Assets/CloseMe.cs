using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMe : MonoBehaviour
{
   
   [Header("Which panel should open when I close? Leave blank if no panel after me.")]
    public GameObject FollowUpPanel;

   // just turn off the GO I am attached to
   public void CloseThisPanel()
   {
        gameObject.SetActive(false);

        if (FollowUpPanel != null)
        {
            FollowUpPanel.SetActive(true);
        }

   }
    // This must be called to make the Energy bar drain
    public void ResumeTime()
    {
        Time.timeScale = 1;
        print("Time.timeScale = 1 in CloseMe on this GO:"+ gameObject.name);
    }

}
