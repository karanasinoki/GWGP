using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniBullet : MonoBehaviour
{
    private Vector3 m_velocity; // ‘¬“x

    // –ˆƒtƒŒ[ƒ€ŒÄ‚Ño‚³‚ê‚éŠÖ”
    private void Update()
    {
        // ˆÚ“®‚·‚é
        transform.localPosition += m_velocity;
        OffScreen();
    }

    // ’e‚ð”­ŽË‚·‚éŽž‚É‰Šú‰»‚·‚é‚½‚ß‚ÌŠÖ”
    public void Init( float angle, float speed )
    {
        // ’e‚Ì”­ŽËŠp“x‚ðƒxƒNƒgƒ‹‚É•ÏŠ·‚·‚é
        var direction = Utils.GetDirection( angle );

        // ”­ŽËŠp“x‚Æ‘¬‚³‚©‚ç‘¬“x‚ð‹‚ß‚é
        m_velocity = direction * speed;

        // ’e‚ªis•ûŒü‚ðŒü‚­‚æ‚¤‚É‚·‚é
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // 2 •bŒã‚Éíœ‚·‚é
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
