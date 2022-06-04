using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreen : Player
{

    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();
        Climb();
    }
    
    void Climb()
    {
        if (Physics2D.OverlapCircle(transform.position, 1).CompareTag("Green")) Jumps = CantJumps;
    }
}
