using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int BulletSpeed = 50;

   
    void Update()
    {
        Move();
        OFFScrean();
    }

    private void Move()
    {
        transform.position += new Vector3(BulletSpeed, 0, 0) * Time.deltaTime;
        
    }
    //Bullet��������v���O����
    private void OFFScrean()
    {
        if(this.transform.position.x>9.0f)
        {
            Destroy(this.gameObject);
        }
    }

    //�e�ƓG�����ł���

    
}
