using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // �e�̃v���n�u

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        // �v���C���[�̈ʒu�ɒe��ݒu
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
