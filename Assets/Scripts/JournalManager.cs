using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    public GameObject[] panelsToHide;
    public GameObject MainMenu;
    public GameObject Birds;
    public GameObject Ori;
  //  public GameObject Shrubs;
    public GameObject Plants;
    public GameObject Food;
    [SerializeField] GameObject Journal;

    private GameObject currentPanel; // Track the currently active panel

    void Start()
    {
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

        if (Birds || Plants || Food || Ori)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
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

    /*public void OpenTrees()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Trees.SetActive(true);
        currentPanel = Trees; // Update the current panel reference
    }*/

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

    public void OpenFood()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food.SetActive(true);
        currentPanel = Food; // Update the current panel reference
    }

    public void HelpOri()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Ori.SetActive(true);
        currentPanel = Ori; // Update the current panel reference
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
        print(panelsToHide.Length);
        for (int i = 1; i < panelsToHide.Length; i++)
        {
            if (panelsToHide[i] == currentPanel)
            {
                if(i == 4)
                {
                  
                    CloseCurrentPanel();
                    panelsToHide[1].SetActive(true);
                    currentPanel = panelsToHide[1];
                    break;
                }
                else
                {
                     CloseCurrentPanel();
                    panelsToHide[i + 1].SetActive(true);
                    currentPanel = panelsToHide[i + 1];
                    print(i);
                    break;
                }
               
            }
        }
    }

    public void BackButton()
    {
        print(panelsToHide.Length);
        for (int i = 1; i < panelsToHide.Length; i++)
        {
            if (panelsToHide[i] == currentPanel)
            {
                if (i == 1)
                {

                    CloseCurrentPanel();
                    panelsToHide[4].SetActive(true);
                    currentPanel = panelsToHide[4];
                    break;
                }
                else
                {
                    CloseCurrentPanel();
                    panelsToHide[i - 1].SetActive(true);
                    currentPanel = panelsToHide[i - 1];
                    print(i);
                    break;
                }

            }
        }
    }
}
