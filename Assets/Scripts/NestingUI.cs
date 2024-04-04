using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NestingUI : MonoBehaviour
{
    public GameObject tree;
    NestingTree treeScript;


    Slider NestingBar;
    // Start is called before the first frame update
    void Start()
    {
        NestingBar = GetComponent<Slider>();
        treeScript = tree.GetComponent<NestingTree>();
    }

    private void Update()
    {
        NestingBar.value = treeScript.NestCompletionAmount / 100f;
    }
}
