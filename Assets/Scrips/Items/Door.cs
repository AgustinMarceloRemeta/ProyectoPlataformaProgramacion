using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer SrUp, SrDown;
    [SerializeField] Sprite SpUp, SpDown;
    [SerializeField] Transform NewDoor;
    [SerializeField] bool EndLevel;
    public static Action SaveMoney;

    public void OpenDoor()
    {
        SrUp.sprite = SpUp;
        SrDown.sprite = SpDown;
        EndLevel = true;
    }
    public void ChangeZone()
    {
        if (EndLevel)
        {
            SaveMoney?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null) ChangeZone();
    }
}
