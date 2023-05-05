using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniBullet : MonoBehaviour
{
    private Vector3 m_velocity; // ���x

    // ���t���[���Ăяo�����֐�
    private void Update()
    {
        // �ړ�����
        transform.localPosition += m_velocity;
        OffScreen();
    }

    // �e�𔭎˂��鎞�ɏ��������邽�߂̊֐�
    public void Init( float angle, float speed )
    {
        // �e�̔��ˊp�x���x�N�g���ɕϊ�����
        var direction = Utils.GetDirection( angle );

        // ���ˊp�x�Ƒ������瑬�x�����߂�
        m_velocity = direction * speed;

        // �e���i�s�����������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // 2 �b��ɍ폜����
        Destroy( gameObject, 10 );
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
