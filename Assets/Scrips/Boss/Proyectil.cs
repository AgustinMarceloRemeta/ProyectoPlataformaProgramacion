using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : Enemy
{
    [SerializeField] float KeyVelocity;
    public override void Update()
    {
        base.Update();
        ToDie = false;
        
    }
    public override void Mov()
    {
        this.transform.Translate(new Vector3(-KeyVelocity* Time.deltaTime, 0),Space.Self);
    }
}
