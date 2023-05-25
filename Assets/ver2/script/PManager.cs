using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PManager : MonoBehaviour
{

    public float moveSpeed = 10f;  // �ړ����x
    public float slowdownRate = 0.5f;  // ������
    public float friction = 7f;  // ���C

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ���L�[�̓��͂��擾
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // �ړ��x�N�g�����v�Z
        movementInput = new Vector2(moveX, moveY);

        // ���͂�����ꍇ�͈ړ��t���O��L����
        isMoving = movementInput.magnitude > 0f;
    }

    private void FixedUpdate()
    {
        // �ړ����x���v�Z
        float currentMoveSpeed = moveSpeed;

        // Shift�L�[�������Ă���ꍇ�͑��x������
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentMoveSpeed *= slowdownRate;
        }

        // �ړ��x�N�g���𐳋K�����đ��x��K�p
        Vector2 moveVelocity = movementInput.normalized * currentMoveSpeed;

        // ��ʊO�ɍs���Ȃ��悤�ɐ���
        Vector2 clampedPosition = rb.position + moveVelocity * Time.fixedDeltaTime;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -9f, 9f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5f, 5f);

        // Rigidbody2D�ɑ��x��K�p
        rb.MovePosition(clampedPosition);

        // ���͂��Ȃ��ꍇ�͑��x������
        if (!isMoving)
        {
            rb.velocity = rb.velocity * (1f - friction * Time.fixedDeltaTime);
        }
    }



}
