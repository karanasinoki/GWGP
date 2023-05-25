using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PManager : MonoBehaviour
{

    public float moveSpeed = 10f;  // 移動速度
    public float acceleration = 10f;  // 加速度
    public float deceleration = 10f;  // 減速度
    public float maxSpeed = 10f;  // 最大速度

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
        // 現在の速度を取得
        Vector2 currentVelocity = rb.velocity;

        // 目標速度を計算
        Vector2 targetVelocity = movementInput * moveSpeed;

        // 加速度と減速度を適用
        if (isMoving)
        {
            targetVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            targetVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }

        // 最大速度を制限
        targetVelocity = Vector2.ClampMagnitude(targetVelocity, maxSpeed);

        // 画面外に行かないように制限
        Vector2 clampedPosition = rb.position + targetVelocity * Time.fixedDeltaTime;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -9f, 9f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5f, 5f);

        // Rigidbody2Dに速度を適用
        rb.MovePosition(clampedPosition);
        rb.velocity = targetVelocity;
    }


}
