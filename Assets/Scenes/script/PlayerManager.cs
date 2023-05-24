using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //プレイヤーの移動速度
    [SerializeField] float highSpeed, SpeedMagnification;
    float currentSpeed;

    private void Start()
    {
        currentSpeed = highSpeed;
    }
    //ゲームオブジェクトを取得
    public GameObject BulletPrehab;
    public GameObject FiringPosition;
    private void Update()
    {
        Move();
        ShiftSlow();
       // Shot();
    }
    //プレイヤーを移動させる関数
    private void Move()
    {
        //キーの入力値を取得
        float movex = Input.GetAxis("Horizontal") * Time.deltaTime*currentSpeed;

        float movey = Input.GetAxis("Vertical")*Time.deltaTime*currentSpeed;
        //取得した入力値を反映させる
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + movex, -8.5f, 8.5f),
                                         Mathf.Clamp(transform.position.y + movey, -4.7f, 4.7f));
    }

    //Shift時に低速となるプログラム

    private void ShiftSlow()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //通常スピードにダッシュスピードをかける
            currentSpeed = highSpeed*SpeedMagnification;
        }
        //スペースが押されてない場合（通常時）
        else
        {
            //通常スピードに戻す
            currentSpeed = highSpeed;
        }
    }

    //Zを押すと弾が固定される
    //private void Shot()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        Instantiate(BulletPrehab,
    //                FiringPosition.transform.position,
    //                transform.rotation);

    //    }

    //}



}
