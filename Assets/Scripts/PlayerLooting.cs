using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerLooting : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public AudioSource source;
    [HideInInspector] public int value; // Value player has
    [HideInInspector] public int cash; // Cash player has

    private void Start() {
        source.enabled = false;
        inventoryText.text = "Value: 0";
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if(c.gameObject.CompareTag("Loot")) {
            // Loot
            value += c.GetComponent<LootValues>().value;
            c.gameObject.SetActive(false);
            inventoryText.text = "Value: " + value;
            c.GetComponent<LootValues>().updateInventory();
            source.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c) {
        if(c.CompareTag("Loot")) {
            source.enabled = false;
        }
    }

    public void ChangeValue(int v) {
        inventoryText.text = "Value: " + v;
        value = v;
    }
}
