using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Grey, Green, Red, Blue, Yellow;
    [SerializeField] Transform Appearance;
    public GameObject PlayerActive;
    public int Life;
    [SerializeField] GameObject[] harts;
    void Start()
    {
        
    }

    void Update()
    {
        Colors();
    }
  
    void Change(GameObject PlayerNew)
    {
        PlayerActive = GameObject.FindGameObjectWithTag("Player");
        Appearance.position = PlayerActive.transform.position;
        Destroy(PlayerActive);
        Instantiate(PlayerNew, Appearance.position,Quaternion.identity);       
    }
    void Colors()
    {
        if (Input.GetKeyDown("1")) Change(Grey);
        else if (Input.GetKeyDown("2")) Change(Green);
        else if (Input.GetKeyDown("3")) Change(Red);
        else if (Input.GetKeyDown("4")) Change(Blue);
        //else if (Input.GetKeyDown("5")) Change(Yellow);
    }
    #region life
    void LifeVisual()
    {
        foreach (var item in harts)
        {
            if(item.activeInHierarchy == true)
            {
                item.GetComponent<Harts>().life--;
                break;
            }
        }
    }
    public void ResetLife()
    {
        foreach (var item in harts) item.GetComponent<Harts>().life = 2;
    }
    public void RestLife()
    {
        Life--;
        LifeVisual();
        if (Life == 0) Die();
        
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
