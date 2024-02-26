using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject display;
    public float cooldownSeconds = 1f;
    private bool state = false;
    private bool cooldown = false;

    private void Start()
    {
        display.SetActive(false);
    }

    private void Update() {
        if(Input.GetAxisRaw("Inventory") > 0 && !cooldown) {
            if(state) {
                // Open
                display.SetActive(true);
            } else {
                // Close
                display.SetActive(false);
            }
            state = !state;
            StartCoroutine(Cooldown());
        }
    }

    public IEnumerator Cooldown() {
        cooldown = true;
        yield return new WaitForSeconds(cooldownSeconds);
        cooldown = false;
    }

}
