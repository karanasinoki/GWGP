using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // �e�̃v���n�u
    public float minDistance = 5f;  // �O��̒e�Ƃ̍ŏ�����
    public int maxBulletCount = 4;  // �ő�̒e��

    private GameObject[] bullets;  // �e�̔z��
    private int bulletCount;  // ���˂��ꂽ�e�̃J�E���g

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnBullet();
            bulletCount++;

            if (bulletCount >= maxBulletCount)
            {
                CalculateTriangleArea();
               
            }
            if(bulletCount>maxBulletCount)
            {
                Destroy(bullets[(bulletCount - maxBulletCount) % maxBulletCount]);
            }
        
        }
    }

    void SpawnBullet()
    {
        // �e�̃C���X�^���X�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // �e�̑��x�Ɠ����蔻��𖳌���
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.isKinematic = true;
        }

        Collider bulletCollider = bullet.GetComponent<Collider>();
        if (bulletCollider != null)
        {
            bulletCollider.enabled = false;
        }

        // �e��ǉ����čő�e���𒴂����ꍇ�͌Â����ɍ폜
        if (bullets == null)
        {
            bullets = new GameObject[maxBulletCount];
        }

        bullets[bulletCount % maxBulletCount] = bullet;
    }

    void CalculateTriangleArea()
    {
        // �O�p�`�̒��_�ƂȂ�ʒu�����擾
        Vector3[] bulletPositions = new Vector3[maxBulletCount];
        for (int i = 0; i < maxBulletCount; i++)
        {
            bulletPositions[i] = bullets[(bulletCount - maxBulletCount + 1 + i) % maxBulletCount].transform.position;
        }

        // �O�p�`�̖ʐς��v�Z
        float area = CalculateAreaOfTriangle(bulletPositions[0], bulletPositions[1], bulletPositions[2]);

        Debug.Log("Triangle Area: " + area);
    }

    float CalculateAreaOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float a = Vector3.Distance(p1, p2);
        float b = Vector3.Distance(p2, p3);
        float c = Vector3.Distance(p3, p1);
        float s = (a + b + c) / 2f;

        return Mathf.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

}
