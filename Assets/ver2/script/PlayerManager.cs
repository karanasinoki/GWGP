using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 10f;//�ړ����x
    public float slowdownRate = 0.5f;//������

    private Rigidbody2D rb;

    private void start()
    {
        rb = GetCompornent<Rigidbody2D>();

    }

    private void Update()
    {
        //���L�[�̓��͂��擾
        float moveX Input.GetAxis("Horizontal");
        float moveY Input.GetAxis("Vertical");

        //�ړ����x���v�Z
        float currentMoveSpeed = moveSpeed;

        //Shift�������Ă���ꍇ����
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentMoveSpeed *= slowdownRate;
        }

        // �ړ��x�N�g�����v�Z
        Vector2 moveDirection = new vecter2(moveX, moveY).normalized;
        Vector2 moveVelocity = moveDirection * currentMoveSpeed;

        //Rigidbody2D�ɑ��x��K�p
        rb.velocity = moveVelocity;
            

    }
    
        
    

}
