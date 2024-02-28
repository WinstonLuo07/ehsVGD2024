using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyManager : MonoBehaviour
{
    public GameObject fire;

    private void Start() {
        Invoke("Explode", GetComponent<Projectile>().lifeTime);
    }

    private void Explode() {
        Instantiate(fire, transform.position, Quaternion.Euler(0f, 0f, 0f));
        Destroy(gameObject);
    }
}
