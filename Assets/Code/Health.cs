using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public int maxHealth = 100;
    public int showMaxHealth;
    [SyncVar] public int currentHealth;
    public Transform healthBar;
    public List<GameObject> flagList;

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
            flagList = new List<GameObject>();
            foreach (GameObject Flag in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (Flag.tag == "NPC" && Flag.GetComponent<NPCControler>().Phe == GetComponent<PlayerController>().Phe)
                {
                    flagList.Add(Flag);
                }
            }
            float minDistance = Vector3.Distance(GetComponent<Transform>().position, flagList[0].GetComponent<Transform>().position);
            GameObject posMinDistance = flagList[0];
            foreach (GameObject flag in flagList)
            {
                if (Vector3.Distance(GetComponent<Transform>().position, flag.GetComponent<Transform>().position) < minDistance)
                {
                    minDistance = Vector3.Distance(GetComponent<Transform>().position, flag.GetComponent<Transform>().position);
                    posMinDistance = flag;
                    Debug.Log(minDistance);
                }
            }
            currentHealth = maxHealth;
            GetComponent<Mancharacter>().currentMana = GetComponent<Mancharacter>().showMaxMana;
            RpcMoveTo(posMinDistance.GetComponent<Transform>().position);
        }
    }

    [Command]
    public void CmdPushHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
    }

    [ClientRpc]
    void RpcMoveTo(Vector3 newPosition)
    {
        transform.position = newPosition; //this will run in all clients
    }

    private void Update()
    {
        healthBar.localScale = new Vector3(currentHealth / (maxHealth * 1.0f), 1, 1);
    }
}
