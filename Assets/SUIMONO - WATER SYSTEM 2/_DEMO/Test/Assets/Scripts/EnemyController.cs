using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}
public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float move_Speed = 3.5f;

    public float attack_Distance = 1f;
    public float Chase_Player_After_Attack_Distance = 1f;
    public float wait_Before_Attack_Timer = 3f;
    private float attack_Timer;
    private EnemyState enemy_State;
    public GameObject AttackPoint;
    private CharacterSoundFX soundFX4;
    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        soundFX4 = GetComponentInChildren<CharacterSoundFX>();

    }
    void Start()
    {
        enemy_State = EnemyState.CHASE;
        attack_Timer = wait_Before_Attack_Timer;
    }
    // Update is called once per frame
    void Update()
    {
        if(enemy_State == EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if (enemy_State == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }
    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_Speed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_Anim.Walk(false);
        } else enemy_Anim.Walk(true);

      
        if (Vector3.Distance(transform.position,playerTarget.position) <= attack_Distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }
    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemy_Anim.Walk(false);
        attack_Timer += Time.deltaTime;
        if(attack_Timer > wait_Before_Attack_Timer)
        {
            //if (Random.Range(0, 1) > 0)
            //{
            //    enemy_Anim.Attack1(true);
            //    soundFX4.Attack_1();
            //}
            //else
            //{
            //    enemy_Anim.Attack2(true);
            //    soundFX4.Attack_2();
            //}
            enemy_Anim.Attack1(true);
            soundFX4.Attack_1();
            attack_Timer = 0f;
        }

        if(Vector3.Distance(transform.position,playerTarget.position) > attack_Distance + Chase_Player_After_Attack_Distance)
        {
            navAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
        }
    }
    void Activate_AttackPoint()
    {
        AttackPoint.SetActive(true);

    }
    void Deactivate_AttackPoint()
    {
        if (AttackPoint.activeInHierarchy)

        {
           AttackPoint.SetActive(false);
        }
    }
}
