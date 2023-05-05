using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;

    }
}
