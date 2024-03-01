using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicManager : MonoBehaviour
{
    public GameObject mimic;
    public GameObject closedChest;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D c) {
        if(!triggered && c.CompareTag("Player")) {
            triggered = true;
            mimic.SetActive(true);
            closedChest.SetActive(false); 
        }
    }
}
