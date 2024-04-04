using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenCanvasController : MonoBehaviour
{
     [Header("These are all PANELS")]
    public GameObject TitleScreen;
    public GameObject GameIntro;
    public GameObject Level_1_Intro;
    public GameObject Level_2_Intro;
    public GameObject Loss_NoEnergy;
    public GameObject Loss_WindowCrash;
    public GameObject Loss_NoMate;
    public GameObject LossNoNest;
    public GameObject Loss_NoPrepForMigration;
    public GameObject Success_Mating;
    public GameObject Success_Nesting;
    public GameObject Success_Level_1;


    // Start is called before the first frame update
    void Start()
    {
        // Title Screen is on when scene loads
        //TitleScreen.SetActive(true);  // It is the last child of canvas, so will open on top of all other panels
        Time.timeScale = 0;

        // GameIntroPanel is on when scene loads (behind Title)  
        GameIntro.SetActive(true);  // Level_1 intro opens when this panel is closed 

        // ALl the other panals are off at start
        Level_1_Intro.SetActive(false);
        Level_2_Intro.SetActive(false);
        Loss_NoEnergy.SetActive(false);
        Loss_WindowCrash.SetActive(false);
        Loss_NoMate.SetActive(false);
        LossNoNest.SetActive(false);
        Loss_NoPrepForMigration.SetActive(false);
        Success_Mating.SetActive(false);
        Success_Nesting.SetActive(false);
        Success_Level_1.SetActive(false);

    }

}
