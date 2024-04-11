using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] int GameTimer;
    
    void Awake()
    {
        GameTimer = 600;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(gameCountDown());
    }

    private IEnumerator gameCountDown()
    {
        while(true)
        {
            if(GameTimer == 0)
            {
                SceneManager.LoadScene("EndScreen");
            }

            yield return new WaitForSeconds(1);
            if (GameTimer > 0)
            {
                GameTimer--;
            }
        }
    }
}
