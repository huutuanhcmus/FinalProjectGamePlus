using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamege4 : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damege = 1f;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius,layer);
        if(hits.Length > 0 )
        {
            hits[0].GetComponent<HealthScript>().ApplyDamege(damege);
            gameObject.SetActive(false);
        }
    }

}
