using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PManager : MonoBehaviour
{

    public float moveSpeed = 10f;  // �ړ����x
    public float acceleration = 10f;  // �����x
    public float deceleration = 10f;  // �����x
    public float maxSpeed = 10f;  // �ő呬�x

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
        // ���݂̑��x���擾
        Vector2 currentVelocity = rb.velocity;

        // �ڕW���x���v�Z
        Vector2 targetVelocity = movementInput * moveSpeed;

        // �����x�ƌ����x��K�p
        if (isMoving)
        {
            targetVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            targetVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }

        // �ő呬�x�𐧌�
        targetVelocity = Vector2.ClampMagnitude(targetVelocity, maxSpeed);

        // ��ʊO�ɍs���Ȃ��悤�ɐ���
        Vector2 clampedPosition = rb.position + targetVelocity * Time.fixedDeltaTime;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -9f, 9f);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5f, 5f);

        // Rigidbody2D�ɑ��x��K�p
        rb.MovePosition(clampedPosition);
        rb.velocity = targetVelocity;
    }


}
