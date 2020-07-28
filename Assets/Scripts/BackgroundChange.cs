using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public GameObject skyBackground;
    public GameObject treesBackground;
    public GameObject cavern;
    public PlayerMovement player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        CheckDepth();
    }

    private void CheckDepth()
    {
        if (player.transform.position.y < -10)
        {
            cavern.SetActive(true);
            skyBackground.SetActive(false);
            treesBackground.SetActive(false);
        } else
        {
            cavern.SetActive(false);
            skyBackground.SetActive(true);
            treesBackground.SetActive(true);
        }

    }
}
