using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int TouchForDead;
    protected Rigidbody Rb;
    public virtual void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    public abstract void Mov();
    

    
}
