using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float playerEnergy { get; private set; } = 100;

    public void ChangeEnergy(float data)
    {
        playerEnergy += data;
    }

    public void SetEnergy(float data)
    {
        playerEnergy = data;
    }

}
