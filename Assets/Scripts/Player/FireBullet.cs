using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator anim;

    private bool canMove;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(canMove)
        {
            Vector2 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        
    }

    public float Speed
    {
        get
            {
            return speed;
        }
        set
            {
            speed=value;
        }
    }
    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==MyTags.BEETLE_TAG || collision.gameObject.tag==MyTags.SNAIL_TAG || collision.gameObject.tag==MyTags.BOSS_TAG|| collision.gameObject.tag == MyTags.SPIDER_TAG)
        {
            canMove = false;
            anim.Play("BulletShoot");
            StartCoroutine(DisableBullet(0.2f));
            //collision.gameObject.SetActive(false);
        }
    }
}//classend
