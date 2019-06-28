using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private float x_Death = -90f;
    //private CharacterAnimations playerAnimations2;
    //private Animator anim;
    private float death_Smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;
    public bool isPlayer;

    [HideInInspector]
    public bool shieldActivated;

    [SerializeField]
    private Image health_UI;

    private CharacterSoundFX soundFX3;
    void Awake()
    {
        soundFX3 = GetComponentInChildren<CharacterSoundFX>();
    }

    public void ApplyDamege(float damege)
    {
        if(shieldActivated)
        {
            return;
        }
        health -= damege;
        
        if(health_UI != null)
        {
            health_UI.fillAmount = health / 100f;
            
        }
        if(health <= 0)
        {
            //soundFX3.Die();
            GetComponent<Animator>().enabled = false;
                StartCoroutine(AllowRotate());
                if (isPlayer)
                {
                    GetComponent<PlayerMoving>().enabled = false;
                    GetComponent<PlayerAttackInput>().enabled = false;  // nhan vat khong the di chuyen hay tan cong sau khi chet
                    Camera.main.transform.SetParent(null);   // camera ko bi thay doi sau khi nhan vat die
                    GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false; // enemy ngung tan cong
                    
                } else
                {
                    GetComponent<EnemyController>().enabled = false;  // enemy ngung tan cong
                    GetComponent<NavMeshAgent>().enabled = false;
                }
        } // Apply damege
    }



    // Update is called once per frame
    void Update()
    {
        if(playerDied)
        {
            RotateAfterDeath();
        }
    }
    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(Mathf.Lerp(transform.eulerAngles.x, x_Death, Time.deltaTime * death_Smooth), transform.eulerAngles.y, transform.eulerAngles.z);
    }
    IEnumerator AllowRotate()
    {
        playerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        playerDied = false;
     
    }
}
