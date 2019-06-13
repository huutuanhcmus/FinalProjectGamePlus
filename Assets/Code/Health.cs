using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar] public int currentHealth = maxHealth;
    public Transform healthBar;

    [Command]
    public void TakeDame(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }

    private void Update()
    {
        healthBar.localScale = new Vector3(currentHealth / (maxHealth * 1.0f), 1, 1);
    }
}
