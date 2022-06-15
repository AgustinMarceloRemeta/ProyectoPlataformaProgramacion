using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer SrUp, SrDown;
    [SerializeField] Sprite SpUp, SpDown;
    [SerializeField] Transform NewDoor;
    [SerializeField] bool EndLevel;

    public void OpenDoor()
    {
        SrUp.sprite = SpUp;
        SrDown.sprite = SpDown;
        EndLevel = true;
    }
    public void ChangeZone()
    {
      if (EndLevel) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }
}
