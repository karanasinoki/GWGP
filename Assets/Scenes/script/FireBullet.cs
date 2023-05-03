using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BulletPrehab;
    public GameObject FiringPosition;
    void Start()
    {
        Shot();
    }
    
        

    private void Shot()
    {
        Instantiate(
            BulletPrehab,
            FiringPosition.transform.position,
            transform.rotation
            ) ;
    }

   
}
