using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public OmniBullet m_shotPrefab; // �e�̃v���n�u
    public float m_shotSpeed; // �e�̈ړ��̑���
    public float m_shotAngleRange; // �����̒e�𔭎˂��鎞�̊p�x
    public float m_shotTimer; // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[
    public int m_shotCount; // �e�̔��ː�
    public float m_shotInterval; // �e�̔��ˊԊu�i�b�j

    private void Update()
    {
        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[���X�V����
        m_shotTimer += Time.deltaTime;

        // �܂��e�̔��˃^�C�~���O�ł͂Ȃ��ꍇ�́A�����ŏ������I����
        if ( m_shotTimer < m_shotInterval ) return;

        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g����
        m_shotTimer = 0;

        // �e�𔭎˂���
        ShootNWay( 180, m_shotAngleRange, m_shotSpeed, m_shotCount );
        
    }
    // �e�𔭎˂���֐�
    private void ShootNWay( 
    float angleBase, float angleRange, float speed, int count )
{
    var pos = transform.localPosition; // �v���C���[�̈ʒu
    var rot = transform.localRotation; // �v���C���[�̌���

    // �e�𕡐����˂���ꍇ
    if ( 1 < count )
    {
        // ���˂���񐔕����[�v����
        for ( int i = 0; i < count; ++i )
        {
            // �e�̔��ˊp�x���v�Z����
            var angle = angleBase + 
                angleRange * ( ( float )i / ( count - 1 ) - 0.5f );

            // ���˂���e�𐶐�����
            var shot = Instantiate( m_shotPrefab, pos, rot );

            // �e�𔭎˂�������Ƒ�����ݒ肷��
            shot.Init( angle, speed );
        }
    }
    // �e�� 1 �������˂���ꍇ
    else if ( count == 1 )
    {
        // ���˂���e�𐶐�����
        var shot = Instantiate( m_shotPrefab, pos, rot );

        // �e�𔭎˂�������Ƒ�����ݒ肷��
        shot.Init( angleBase, speed );
    }
}
}
