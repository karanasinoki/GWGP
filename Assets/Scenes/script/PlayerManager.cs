using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    private int MoveSpeed = 12;
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
        float movex = Input.GetAxis("Horizontal") * Time.deltaTime*MoveSpeed;

        float movey = Input.GetAxis("Vertical")*Time.deltaTime*MoveSpeed;
        //�擾�������͒l�𔽉f������
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + movex, -8.5f, 8.5f),
                                         Mathf.Clamp(transform.position.y + movey, -4.7f, 4.7f));
    }

    //�X�y�[�X�������ƒe�����˂����
    private void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {             
            Instantiate(BulletPrehab,
                    FiringPosition.transform.position,
                    transform.rotation);

        }
        
    }

    

}
