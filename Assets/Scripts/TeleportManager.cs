using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject teleportTo;
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.gameObject.transform.position = teleportTo.transform.position;
        }
    }
}
