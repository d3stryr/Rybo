using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;

    private int health = 10;

    private bool canDamage;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==MyTags.BULLET_TAG)
        {
            Debug.Log(health);
            if(canDamage)
            {
                health--;
                canDamage = false;
                if (health == 0)
                {
                    
                    anim.Play("BossDead");
                    StopCoroutine(WaitForDamage());
                }
                StartCoroutine(WaitForDamage());
            }
        }
    }

    void DisableBoss()
    {
        StartCoroutine(DealBoss());
    }

    IEnumerator DealBoss()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BossScripts>().DeactivateBossAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//class end
