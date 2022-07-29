using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] GameObject NormalKey;
    [SerializeField] GameObject [] keys;
    [SerializeField] Transform ShootNormal;
    [SerializeField] Transform[] Shoots, ShootsAirs;
public void RandomKey()
    {
      int random =  Random.Range(0,5);
        if (random == 0) Instantiate(NormalKey, ShootNormal.position, Quaternion.identity);
        
        else if (random == 1)
        {
            int random2 = Random.Range(0, keys.Length);
            foreach (var i in Shoots) Instantiate(keys[random2], i.position,Quaternion.identity);
        }     
        else if (random == 2)
        {
            foreach (var i in ShootsAirs) Instantiate(keys[Random.Range(0,keys.Length)], i.position,i.rotation);
        }
        
        else return;
    }
    public override void Mov()
    {
        
    }
}
