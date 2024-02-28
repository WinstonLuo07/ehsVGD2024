using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] float time = 0.5f, damge = 1f, lifeTime = 2f;
    [SerializeField] bool takeDamage = true;

    private void Start() {
        Invoke("DestroyFlame", lifeTime);
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(c.tag.Contains("Enemy")) {
            if(c.CompareTag("ChaseEnemy")) {
                StartCoroutine(TakeDamage(time, c, "ch"));
            }
        }
    }

    private void DestroyFlame() {
        Destroy(gameObject);
    }

    IEnumerator TakeDamage(float time, Collider2D c, String type)
    {
        if (takeDamage) {
            if(type == "ch") {
                c.GetComponent<ChasingHostile>().ChangeHealth(-1*damge);
                takeDamage = !takeDamage;
                yield return new WaitForSeconds(time);
                takeDamage = !takeDamage;
            }
        }

    }
}
