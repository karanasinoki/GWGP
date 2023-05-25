using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PManager : MonoBehaviour
{

    public float moveSpeed = 10f;  // 移動速度
    public float slowdownRate = 0.5f;  // 減速率
    public float friction = 7f;  // 摩擦

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 矢印キーの入力を取得
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 移動ベクトルを計算
        movementInput = new Vector2(moveX, moveY);

        // 入力がある場合は移動フラグを有効化
        isMoving = movementInput.magnitude > 0f;
    }

    private void FixedUpdate()
    {
        // 移動速度を計算
        float currentMoveSpeed = moveSpeed;

        // Shiftキーを押している場合は速度を減速
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentMoveSpeed *= slowdownRate;
        }

        // 移動ベクトルを正規化して速度を適用
        Vector2 moveVelocity = movementInput.normalized * currentMoveSpeed;

        // 画面外に行かないように制限
        Vector2 clampedPosition = rb.position + moveVelocity * Time.fixedDeltaTime;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -9f, 9f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5f, 5f);

        // Rigidbody2Dに速度を適用
        rb.MovePosition(clampedPosition);

        // 入力がない場合は速度を減速
        if (!isMoving)
        {
            rb.velocity = rb.velocity * (1f - friction * Time.fixedDeltaTime);
        }
    }



}
