using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int BulletSpeed = 10;

   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(BulletSpeed, 0, 0) * Time.deltaTime;
        
    }
}
