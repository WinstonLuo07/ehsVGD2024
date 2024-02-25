using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public float cooldownSeconds = 1f;
    private bool state = false;
    private bool cooldown = false;

    private void Update() 
    {
        if(Input.GetAxisRaw("Inventory") > 0 && !cooldown) 
        {
            if(state) {
                // Open
                GetComponent<Canvas>().enabled = true;
            } else {
                // Close
                GetComponent<Canvas>().enabled = false;
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
