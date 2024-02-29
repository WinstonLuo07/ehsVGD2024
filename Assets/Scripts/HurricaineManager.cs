using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurricaineManager : MonoBehaviour
{
    public GameObject player;
    public float lifeTime = 5f;
    public float damage = 0.5f;
    [HideInInspector] public float degrees = 1f;

    private void Start() {
        transform.SetParent(player.transform);
        Invoke("DestroyObject", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if(c.tag.Contains("Enemy")) {
            // Hit Enemy
            if(c.CompareTag("ChaseEnemy")) c.GetComponent<ChasingHostile>().ChangeHealth(-1*damage);
        }
    }

    private void Update() {
        transform.RotateAround(player.transform.position, new Vector3(0f, 0f, 1f), degrees);
    }
    
    private void DestroyObject() {
        Destroy(gameObject);
    }

}
