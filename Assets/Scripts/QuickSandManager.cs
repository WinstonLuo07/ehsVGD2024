using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSandManager : MonoBehaviour
{
    public float slowFactor = 0.7f;
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.GetComponent<PlayerMovement>().moveSpeed = 2.5f * slowFactor;
        } else if(c.gameObject.CompareTag("ChaseEnemy")) {
            c.GetComponent<ChasingHostile>().speed = c.GetComponent<ChasingHostile>().speed * slowFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.GetComponent<PlayerMovement>().moveSpeed = 2.5f;
        } else if(c.gameObject.CompareTag("ChaseEnemy")) {
            c.GetComponent<ChasingHostile>().speed = c.GetComponent<ChasingHostile>().speed / slowFactor;
        }
    }
}
