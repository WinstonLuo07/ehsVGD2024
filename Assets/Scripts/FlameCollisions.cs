using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlameCollisions : MonoBehaviour
{
    private float damage = 0.5f;
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.tag.Contains("Enemy")) {
            // Hit Enemy
            if(c.CompareTag("ChaseEnemy")) c.GetComponent<ChasingHostile>().ChangeHealth(-1*damage);
        }
    }
}
