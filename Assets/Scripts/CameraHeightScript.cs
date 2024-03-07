using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float height;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + height, transform.position.z);
    }
}
