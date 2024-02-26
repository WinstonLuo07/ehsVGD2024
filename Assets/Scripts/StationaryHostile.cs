using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StationaryHostile : MonoBehaviour
{
    public float damage = 1.0f;
    
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.GetComponent<PlayerHealthManager>().ChangeHealth(damage*-1f);
        }
    }
}
