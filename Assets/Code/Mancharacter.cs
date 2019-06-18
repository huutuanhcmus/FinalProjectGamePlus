using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Mancharacter : NetworkBehaviour
{
    public const int maxMana = 100;
    public int showMaxMana = maxMana;
    public Transform manaBar;
    [SyncVar] public int currentMana = maxMana;

    [Command]
    public void CmdTakeMana(int amount)
    {
        
            currentMana -= amount;
            Debug.Log(currentMana);
            
    }

    public void CmdPushMana(int amount)
    {
        currentMana += amount;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }

    public int getManaCurrent()
    {
        return currentMana;
    }

    private void Update()
    {
        manaBar.localScale = new Vector3(currentMana / (maxMana * 1.0f), 1, 1);
    }
}
