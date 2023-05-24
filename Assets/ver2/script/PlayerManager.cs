using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 10f;//移動速度
    public float slowdownRate = 0.5f;//減速率

    private Rigidbody2D rb;

    private void start()
    {
        rb = GetCompornent<Rigidbody2D>();

    }

    private void Update()
    {
        //矢印キーの入力を取得
        float moveX Input.GetAxis("Horizontal");
        float moveY Input.GetAxis("Vertical");

        //移動速度を計算
        float currentMoveSpeed = moveSpeed;

        //Shiftを押している場合減速
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentMoveSpeed *= slowdownRate;
        }

        // 移動ベクトルを計算
        Vector2 moveDirection = new vecter2(moveX, moveY).normalized;
        Vector2 moveVelocity = moveDirection * currentMoveSpeed;

        //Rigidbody2Dに速度を適用
        rb.velocity = moveVelocity;
            

    }
    
        
    

}
