using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    private int MoveSpeed = 8;
    //�Q�[���I�u�W�F�N�g���擾
    public GameObject BulletPrehab;
    public GameObject FiringPosition;
    private void Update()
    {
        Move();
        Shot();
    }
    //�v���C���[���ړ�������֐�
    private void Move()
    {
        //�L�[�̓��͒l���擾
        float x = Input.GetAxis("Horizontal")*MoveSpeed;
        float y = Input.GetAxis("Vertical")*MoveSpeed;
        //�擾�������͒l�𔽉f������
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;

    }

    //�X�y�[�X�������ƒe�����˂����
    private void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {             
            Instantiate(BulletPrehab,
                    FiringPosition.transform.position,
                    transform.rotation);

        }
        
    }

}
