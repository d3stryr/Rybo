using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(fireBullet,transform.position,Quaternion.identity);
            bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
        }
    }
}//classend
