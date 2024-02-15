using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int playerEnergy;

    public void ChangeEnergy(int data)
    {
        playerEnergy += data;
    }

}
