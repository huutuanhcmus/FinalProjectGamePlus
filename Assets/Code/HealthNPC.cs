using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HealthNPC : NetworkBehaviour
{
    public int maxHealth = 1000;
    public int showMaxHealth;
    [SyncVar] public int currentHealth;
    public Transform healthBar;

    private void Start()
    {
        showMaxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    [Command]
    public void CmdTakeDame(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            var temp = (GameObject)Instantiate(GetComponent<NPCControler>().PheDich, gameObject.transform.position, gameObject.transform.rotation);
            NetworkServer.Spawn(temp);
            NetworkServer.Destroy(gameObject);

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
