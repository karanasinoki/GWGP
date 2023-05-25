using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // 弾のプレハブ
    public float minDistance = 5f;  // 前回の弾との最小距離
    public int maxBulletCount = 4;  // 最大の弾数

    private GameObject[] bullets;  // 弾の配列
    private int bulletCount;  // 発射された弾のカウント

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
        // 弾のインスタンスを生成
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 弾の速度と当たり判定を無効化
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

        // 弾を追加して最大弾数を超えた場合は古い順に削除
        if (bullets == null)
        {
            bullets = new GameObject[maxBulletCount];
        }

        bullets[bulletCount % maxBulletCount] = bullet;
    }

    void CalculateTriangleArea()
    {
        // 三角形の頂点となる位置情報を取得
        Vector3[] bulletPositions = new Vector3[maxBulletCount];
        for (int i = 0; i < maxBulletCount; i++)
        {
            bulletPositions[i] = bullets[(bulletCount - maxBulletCount + 1 + i) % maxBulletCount].transform.position;
        }

        // 三角形の面積を計算
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
