using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamege : MonoBehaviour
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
    }

}
