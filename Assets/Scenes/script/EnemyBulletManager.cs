using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    private int BulletSpeed = 1;

    private void Start()
    {
       
    }


    void Update()
    {
         Move();
        OFFScrean();
    }

    private void Move()
    {
        if(this.transform.position.x<6.2)
        {
             transform.position += new Vector3(-BulletSpeed, 0, 0) * Time.deltaTime;

        }
       
    }
    //Bullet‚ªÁ‚¦‚éƒvƒƒOƒ‰ƒ€
    private void OFFScrean()
    {
        if (this.transform.position.x < -9.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
