using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : Enemy
{
    [Header("Mov Fly")]
    [Range(0f, 3f)]
    [SerializeField] private float amplitude;

    [Range(0f, 3f)]
    [SerializeField] private float frecuency;
    float sinCenterY;


    public override void Start()
    {
        base.Start();
        sinCenterY = this.transform.position.y;
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Mov()
    {
        Vector2 pos = this.transform.position;
        float sin = Mathf.Sin(pos.x * frecuency) * amplitude;
        pos.y = sinCenterY + sin;
        this.transform.position = pos;
        MovHorizontal();
        
    }
}
