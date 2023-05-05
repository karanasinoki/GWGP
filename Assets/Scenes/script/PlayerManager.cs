using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    [SerializeField] float highSpeed, SpeedMagnification;
    float currentSpeed;

    private void Start()
    {
        currentSpeed = highSpeed;
    }
    //�Q�[���I�u�W�F�N�g���擾
    public GameObject BulletPrehab;
    public GameObject FiringPosition;
    private void Update()
    {
        Move();
        ShiftSlow();
        Shot();
    }
    //�v���C���[���ړ�������֐�
    private void Move()
    {
        //�L�[�̓��͒l���擾
        float movex = Input.GetAxis("Horizontal") * Time.deltaTime*currentSpeed;

        float movey = Input.GetAxis("Vertical")*Time.deltaTime*currentSpeed;
        //�擾�������͒l�𔽉f������
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + movex, -8.5f, 8.5f),
                                         Mathf.Clamp(transform.position.y + movey, -4.7f, 4.7f));
    }

    //Shift���ɒᑬ�ƂȂ�v���O����

    private void ShiftSlow()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //�ʏ�X�s�[�h�Ƀ_�b�V���X�s�[�h��������
            currentSpeed = highSpeed*SpeedMagnification;
        }
        //�X�y�[�X��������ĂȂ��ꍇ�i�ʏ펞�j
        else
        {
            //�ʏ�X�s�[�h�ɖ߂�
            currentSpeed = highSpeed;
        }
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
