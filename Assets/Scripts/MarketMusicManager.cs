using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketMusicManager : MonoBehaviour
{
    public AudioSource market;
    public AudioSource cave;
    /*
    private void Start() {
        source = GetComponent<AudioSource>();
        source.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            source.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            source.enabled = false;
        }
    }*/
    private void Update()
    {
        float level = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManagementSystem>().level;

        if (level == 0)
        {
            if (market)
            {
                market.enabled = true;
            }
            if (cave)
            {
                cave.enabled = false;
            }
            
        }

        else if (level > 0)
        {
            if (market)
            {
                market.enabled = false;
            }
            if (cave)
            {
                cave.enabled = true;
            }
        }
    }
}
