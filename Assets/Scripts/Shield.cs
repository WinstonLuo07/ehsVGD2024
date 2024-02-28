using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    public float lifeTime = 10f;

    private void Start() {
        Invoke("DestroyObject", lifeTime);
    }

    private void Update() {
        //this.transform.position = player.transform.position;
        transform.SetParent(player.transform);
        transform.Rotate(new Vector3 (0f, 0f, speed) * Time.deltaTime);
    }

    private void DestroyObject() {
        Destroy(gameObject);
    }
}
