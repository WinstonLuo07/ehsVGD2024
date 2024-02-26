using System.Collections;
using UnityEngine;

public class ChasingHostile : MonoBehaviour
{
    public float enemyHealth = 5.0f;
    public float damage = 2.0f;
    public float speed = 3f;
    public GameObject player;
    public float maxDistanceForFollow = 5f;
    private float d; // Distance
    private bool cooldown = false;
    private Vector2 wayPoint;
    
    private void Start() {
        SetNewDestination();
    }

    private void Update() {
        d = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position; // Direction for animations

        if(d <= maxDistanceForFollow && !cooldown) {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        } else {
            transform.position = Vector2.MoveTowards(this.transform.position, wayPoint, speed * Time.deltaTime * 2/3);
            if(Vector2.Distance(transform.position, wayPoint) < 2f) SetNewDestination();
        }
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            c.GetComponent<PlayerHealthManager>().ChangeHealth(damage*-1f);
            StartCoroutine(CoolDown());
        }
        if(c.CompareTag("StationaryEnemy")) {
            Debug.Log("HIT");
            ChangeHealth(c.GetComponent<StationaryHostile>().damage*-1f);
        }
    }

    IEnumerator CoolDown() {
        cooldown = true;
        yield return new WaitForSeconds(0.25f);
        cooldown = false;
    }

    private void SetNewDestination() {
        wayPoint = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    public float ChangeHealth(float v) {
        enemyHealth += v;
        if(enemyHealth <= 0) { // Enemy Dead
            gameObject.SetActive(false);
        }
        return enemyHealth;
    }

}
