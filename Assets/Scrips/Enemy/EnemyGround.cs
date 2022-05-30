using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround: Enemy
{
    [Range(0, 10)]
    public float Limit;
    [SerializeField] private bool right;
    [SerializeField] private float velocity;
    private float negative, positive;
    public override void Start()
    {
        base.Start();
        negative = transform.position.x - Limit;
        positive = transform.position.x + Limit;
    }


    void Update()
    {
        Mov();
    }
    public override void Mov() 
    {
        transform.Translate(velocity* Time.deltaTime , 0, 0);
        if (transform.position.x > positive) right = false;
        if (transform.position.x < negative) right = true;
        if (right) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!right) transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
