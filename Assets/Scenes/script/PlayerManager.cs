using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //プレイヤーの移動速度
    private int MoveSpeed = 8;
    //ゲームオブジェクトを取得
    public GameObject BulletPrehab;
    public GameObject FiringPosition;
    private void Update()
    {
        Move();
        Shot();
    }
    //プレイヤーを移動させる関数
    private void Move()
    {
        //キーの入力値を取得
        float x = Input.GetAxis("Horizontal")*MoveSpeed;
        float y = Input.GetAxis("Vertical")*MoveSpeed;
        //取得した入力値を反映させる
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;

    }

    //スペースを押すと弾が発射される
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
