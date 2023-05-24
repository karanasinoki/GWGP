using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniBullet : MonoBehaviour
{
    private Vector3 m_velocity; // 速度

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // 移動する
        transform.localPosition += m_velocity;
        OffScreen();
    }

    // 弾を発射する時に初期化するための関数
    public void Init( float angle, float speed )
    {
        // 弾の発射角度をベクトルに変換する
        var direction = Utils.GetDirection( angle );

        // 発射角度と速さから速度を求める
        m_velocity = direction * speed;

        // 弾が進行方向を向くようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Bullet"))
        {
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
        } 
    }

    private void OffScreen()
    {
        if (this.transform.position.x>9.1f||this.transform.position.x<-9.1f||
            this.transform.position.y>5.2f||this.transform.position.y<-5.2f)
        {
            Destroy(this.gameObject);
        }

    }
       

}
