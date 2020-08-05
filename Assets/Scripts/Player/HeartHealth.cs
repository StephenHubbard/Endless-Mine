using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netherforge.Combat;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{
    Health health;
    PlayerMovement player;
    float currentHealth;

    public Image[] hearts;

    public Sprite emptyHeart;
    public Sprite halfHeart;
    public Sprite fullHeart;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        health = player.GetComponent<Health>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        updateHealthHearts();
    }

    private void updateHealthHearts()
    {
        currentHealth = health.currentHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

        }
    }
}
