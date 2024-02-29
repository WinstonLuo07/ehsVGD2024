using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public GameObject loot;
    public GameObject open;
    public GameObject closed;
    private bool looted = false;
    private void OnTriggerStay2D(Collider2D c) {
        if(!looted && c.CompareTag("Player") && Input.GetAxisRaw("Interact") > 0) {
            open.SetActive(true);
            closed.SetActive(false);
            loot.SetActive(true);
            looted = true;
        }
    }
}
