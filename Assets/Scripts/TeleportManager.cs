using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject teleportTo;
    public bool changeObjective;
    public string objective;
    public LevelManagementSystem lvl;
    public bool exitCave;


    private void OnTriggerEnter2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.gameObject.transform.position = teleportTo.transform.position;
            if(changeObjective) lvl.StartCoroutine(lvl.SetText(objective, 0f));
            if(exitCave) lvl.level++;
        }
    }
}
