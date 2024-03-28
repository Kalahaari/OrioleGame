using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    public GameObject[] panelsToHide;
    public GameObject MainMenu;
    public GameObject Birds;
    public GameObject Trees;
    public GameObject Shrubs;
    public GameObject Plants;
    public GameObject Food;

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
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (MainMenu.activeSelf) // If main menu is active, close it
            {
                CloseCurrentPanel();
            }
            else
            {
                OpenMainMenu();
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

    public void OpenTrees()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Trees.SetActive(true);
        currentPanel = Trees; // Update the current panel reference
    }

    public void OpenShrubs()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Shrubs.SetActive(true);
        currentPanel = Shrubs; // Update the current panel reference
    }

    public void OpenPlants()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Plants.SetActive(true);
        currentPanel = Plants; // Update the current panel reference
    }

    public void OpenFood()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food.SetActive(true);
        currentPanel = Food; // Update the current panel reference
    }

    public void OpenAboutOri()
    {
        CloseCurrentPanel(); // Close the current panel, if any
        Food.SetActive(true);
        currentPanel = Food; // Update the current panel reference
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
}
