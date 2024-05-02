using UnityEngine;

public class JournalManager : MonoBehaviour
{
    //[SerializeField] AudioSource aud;
    public GameObject[] panelsToHide;
    public GameObject MainMenu;
    public GameObject Birds;
    public GameObject Birds2;
    public GameObject Birds3;
    public GameObject Ori1;
    public GameObject Ori2;
    public GameObject Ori3;
    //  public GameObject Shrubs;
    public GameObject Plants;
    public GameObject Plants2;
    public GameObject Plants3;
   

    public GameObject Food;
    public GameObject Food2;
    [SerializeField] GameObject Journal;

    private GameObject currentPanel; // Track the currently active panel

    void Start()
    {
        //aud = GetComponent<AudioSource>();
        // Iterate through each panel and set them inactive
        foreach (GameObject panel in panelsToHide)
        {
            panel.SetActive(false);
        }
    }

    private void Update()
    {
        //if J is pressed Journal Menu Opens

        if (currentPanel == MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Journal.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Journal.activeSelf) // If main menu is active, close it
            {
                Journal.SetActive(false);
            }
            else
            {
                Journal.SetActive(true);
                CloseCurrentPanel();
                MainMenu.SetActive(true);
                currentPanel = MainMenu;
            }
        }

        if (Birds || Plants || Food || Ori1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseCurrentPanel();
                MainMenu.SetActive(true);
                currentPanel = MainMenu;
            }
        }
    }

    public void OpenMainMenu()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        MainMenu.SetActive(true);
        currentPanel = MainMenu; // Update the current panel reference
    }

    public void OpenBirds()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Birds.SetActive(true);
        currentPanel = Birds; // Update the current panel reference
    }
    public void OpenBirds2()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Birds2.SetActive(true);
        currentPanel = Birds2;
    }
    public void OpenBirds3()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Birds3.SetActive(true);
        currentPanel = Birds3;
    }

    public void OpenShrubs()
    {
        //CloseCurrentPanel(); // Close the current panel, if any
        // Shrubs.SetActive(true);
        //currentPanel = Shrubs; // Update the current panel reference
    }

    public void OpenPlants()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Plants.SetActive(true);
        Debug.Log("working");
        currentPanel = Plants; // Update the current panel reference
    }

    public void OpenPlants2()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Plants2.SetActive(true);
        Debug.Log("working");
        currentPanel = Plants2; // Update the current panel reference
    }
    public void OpenPlants3()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Plants3.SetActive(true);
        Debug.Log("working");
        currentPanel = Plants3; // Update the current panel reference
    }
 

    public void OpenFood()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food.SetActive(true);
        currentPanel = Food; // Update the current panel reference
    }
    public void OpenFood2()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food2.SetActive(true);
        currentPanel = Food2; // Update the current panel reference
    }

    public void HelpOri()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Ori1.SetActive(true);
        currentPanel = Ori1; // Update the current panel reference   
    }
    public void HelpOri2()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Ori2.SetActive(true);
        currentPanel = Ori2; // Update the current panel reference   
    }
    public void HelpOri3()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Ori3.SetActive(true);
        currentPanel = Ori3; // Update the current panel reference   
    }

    public void OpenAboutBlock()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food.SetActive(true);
        currentPanel = Food; // Update the current panel reference
    }

    // Method to close the current panel
    public void CloseCurrentPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
    }

    public void NextButton()
    {
        
        //print(panelsToHide.Length);
        for (int i = 1; i < panelsToHide.Length; i++)
        {
            if (panelsToHide[i] == currentPanel)
            {
                if (i == panelsToHide.Length - 1)
                {
                    //aud.Play();
                    CloseCurrentPanel();
                    panelsToHide[1].SetActive(true);
                    currentPanel = panelsToHide[1];
                    break;
                }
                else
                {
                    //aud.Play();
                    CloseCurrentPanel();
                    panelsToHide[i + 1].SetActive(true);
                    currentPanel = panelsToHide[i + 1];
                    print(i);
                    break;
                }

            }
        }
        //aud.Play();
    }

    public void BackButton()
    {
        //print(panelsToHide.Length);
        for (int i = 1; i < panelsToHide.Length; i++)
        {
            if (panelsToHide[i] == currentPanel)
            {
                if (i == 1)
                {
                    
                    CloseCurrentPanel();
                    panelsToHide[panelsToHide.Length - 1].SetActive(true);
                    currentPanel = panelsToHide[panelsToHide.Length - 1];
                    break;
                }
                else
                {
                    //aud.Play();
                    CloseCurrentPanel();
                    panelsToHide[i - 1].SetActive(true);
                    currentPanel = panelsToHide[i - 1];
                    print(i);
                    break;
                }

            }
        }

        //aud.Play();
    }
}
