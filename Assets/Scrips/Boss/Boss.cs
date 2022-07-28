using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject NormalKey;
    [SerializeField] GameObject [] keys;
    [SerializeField] Transform ShootNormal;
    [SerializeField] Transform[] Shoots;
public void RandomKey()
    {
      int random =  Random.Range(0,4);
        if (random == 0) Instantiate(NormalKey, ShootNormal.position, Quaternion.identity);
        
        else if (random == 1)
        {
            int random2 = Random.Range(0, keys.Length);
            foreach (var i in Shoots) Instantiate(keys[random2], i.position,Quaternion.identity);
        }
        
        else return;
    }
}
