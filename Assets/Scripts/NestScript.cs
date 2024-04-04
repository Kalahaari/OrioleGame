using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestScript : MonoBehaviour
{
    [SerializeField] GameObject parentTree;

    NestingTree treeScript;
    // Start is called before the first frame update
    void Start()
    {
        treeScript = parentTree.GetComponent<NestingTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NestingMaterial>())
        {
            Destroy(other.gameObject);
            treeScript.NestCompletionAmount += 25;
        }
    }
}
