using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfShips;

    public Image[] Ships;
    public Sprite ship;
    public GameObject[] damagedSprites;
    public AudioSource audios;

    void Awake()
    {
        EventManager.Instance.SubEvent("LifeLoss", LifeLoss);
    }
    void Start()
    {
        Player player = FindObjectOfType<Player>();
    }

    void LifeLoss(params object[] parameters)
    {
        health = health - 1;
        audios.Play();
       
        if(health <= 0)
        {
            EventManager.Instance.CallEvent("LoseScene");
        }
        for (int i = 0; i < Ships.Length; i++)
        {
            if (i < health)
            {
                Ships[i].sprite = ship;
                
            }
            else
            {
                Ships[i].enabled = false;
            }
        }
        for (int i = 0; i < damagedSprites.Length; i++)
        {
            if(health >= 3)
            {
                damagedSprites[0].SetActive(true);
            }
            else if(health == 2)
            {
                damagedSprites[1].SetActive(true);
            }
            else if(health == 1)
            {
                damagedSprites[2].SetActive(true);
            }
            else
            {
                damagedSprites[i].SetActive(false);
            }
        }

    }

}
