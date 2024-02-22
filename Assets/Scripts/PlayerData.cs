using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int playerEnergy { get; private set; } = 100;

    public void ChangeEnergy(int data)
    {
        playerEnergy += data;
    }

    public void SetEnergy(int data)
    {
        playerEnergy = data;
    }

}
