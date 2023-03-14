using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    public float nextMove_X;
    public float nextMove_Y;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove_X, nextMove_Y);
    }   

    void Think()
    {
        nextMove_X = Random.Range(-1, 2);
        nextMove_Y = Random.Range(-1, 2);
        Invoke("Think", 1);
    }
}