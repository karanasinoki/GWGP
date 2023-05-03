using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //プレイヤーの移動速度
    private int MoveSpeed = 18;
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
        float movex = Input.GetAxis("Horizontal") * Time.deltaTime*MoveSpeed;

        float movey = Input.GetAxis("Vertical")*Time.deltaTime*MoveSpeed;
        //取得した入力値を反映させる
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + movex, -8.5f, 8.5f),
                                         Mathf.Clamp(transform.position.y + movey, -4.7f, 4.7f));
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
