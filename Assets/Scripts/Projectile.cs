using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4f;
    public float lifeTime;
    public float maxDistance = 2f;
    public float damage = 2f;
    private Vector2 target;

    private void Start() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Physics2D.IgnoreLayerCollision(3, 3, true);
        
        // Calculate max distance target
        float d = Vector2.Distance(transform.position, target);
        float dx = target.x - transform.position.x; float dy = target.y - transform.position.y;
        float ay = (5f*dy)/d; float ax = (5f*dx)/d;
        target.x = transform.position.x + ax; target.y = transform.position.y + ay;

        Invoke("DestroyProjectile", lifeTime);
    }
    
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.tag.Contains("Enemy")) {
            // Hit Enemy
            if(c.CompareTag("ChaseEnemy")) c.GetComponent<ChasingHostile>().ChangeHealth(-1*damage);
        }
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
