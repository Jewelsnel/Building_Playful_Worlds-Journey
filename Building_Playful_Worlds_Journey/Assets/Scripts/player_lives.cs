using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_lives : MonoBehaviour
{

    public static int health;
    public static int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float invincibilityTime;




    //public GameManager gameManager;


    private void Start()
    {
        health = 3;
        numOfHearts = 3;
    }

    public void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }

            if (health <= 0f)
            {
                Debug.Log("Je bent doood");
            }
            
        }

    }

    public void Hurt()
    {
        health--;
    }



}
