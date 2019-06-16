using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    public int showMaxHealth = maxHealth;
    [SyncVar] public int currentHealth = maxHealth;
    public Transform healthBar;
    [Command]
    public void CmdTakeDame(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            //RpcRepawn(new Vector3(-540.13f, 14.39f, 222.06f));
            transform.position = new Vector3(-540.13f, 14.39f, 222.06f);
        }
    }

    [Command]
    public void CmdPushHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }



    private void Update()
    {
        healthBar.localScale = new Vector3(currentHealth / (maxHealth * 1.0f), 1, 1);
    }
}
