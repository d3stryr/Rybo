using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D myBody;

    private bool animation_started;
    private bool animation_Finished;

    private int jumpedTimes;

    private bool jumpLeft = true;

    public LayerMask playerLayer;

    private GameObject player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    private void Update()
    {
        if(Physics2D.OverlapCircle(transform.position,0.5f,playerLayer))
        {
            player.GetComponent<PlayerDamage>().DealDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FrogJump());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(animation_Finished && animation_started)
        {
            animation_started = false;
            transform.parent.position = transform.position;
            transform.localPosition = Vector2.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));
        animation_started = true;
        animation_Finished = false;
        jumpedTimes++;
        if(jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(FrogJump());
    }
    void AnimationFinished()
    {
        animation_Finished = true;
        if(jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }
        
        if(jumpedTimes==3)
        {
            jumpedTimes = 0;
            Vector2 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
            jumpLeft = !jumpLeft;
        }
    }
}//class end
