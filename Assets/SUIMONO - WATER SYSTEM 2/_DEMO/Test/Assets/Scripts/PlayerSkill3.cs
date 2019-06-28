using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSkill3 : MonoBehaviour
{
    private HealthScript healthScript;

  

    void Awake()
    {
        healthScript = GetComponent<HealthScript>();
        
    }
    public void ActivateShield(bool shieldActive)
    {
        healthScript.shieldActivated = shieldActive;
    }

    // Update is called once per frame
    void Update()
    {
    
    }


}
