using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSoundManager : MonoBehaviour
{
    private AudioSource source;
    private void Start() {
        source = GetComponent<AudioSource>();
        source.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(c.CompareTag("Player") && Input.GetAxisRaw("Interact") > 0) {
            source.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c) {
        if(c.CompareTag("Player")) {
            source.enabled = false;
        }
    }
}
