using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour
{
    GameObject player;

    [SerializeField] PlayerData pd;

    Slider EnergyBar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        EnergyBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        EnergyBar.value = pd.playerEnergy / 100f;
        if(pd.playerEnergy <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
