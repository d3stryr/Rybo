using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    private Animator anim;

    private Vector3 moveDirection = Vector3.left;

    private Vector3 originPosition;
    private Vector3 movePosition;

    public GameObject birdEgg;

    public LayerMask playerLayer;

    private bool attacked = false;

    private bool canMove;

    private float speed = 3f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;
        movePosition = transform.position;
        movePosition.x -= 6f;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }
    void MoveTheBird()
    {
        if(canMove)
        {
            
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);
            if(transform.position.x>=originPosition.x)
            {
                ChangeDirection();
                moveDirection = Vector3.left;
            }
            else if(transform.position.x<=movePosition.x)
            {
                ChangeDirection();
                moveDirection = Vector3.right;
            }
            
        }
    }
    void ChangeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
    void DropTheEgg()
    {
        if(!attacked)
        {
            if(Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
            {
                Instantiate(birdEgg, new Vector3(transform.position.x,transform.position.y-1f,transform.position.z), Quaternion.identity);
                attacked = true;
                anim.Play("BirdFly");
            }
        }
    }

    IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==MyTags.BULLET_TAG)
        {
            anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;

            myBody.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;

            StartCoroutine(BirdDead());

        }
    }
}//class end

