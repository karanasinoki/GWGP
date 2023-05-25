using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // 弾のプレハブ

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        // プレイヤーの位置に弾を設置
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
