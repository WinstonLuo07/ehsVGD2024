using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerLooting : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    [HideInInspector] public int value; // Value player has

    private void Start() {
        inventoryText.text = "Value: 0";
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if(c.gameObject.CompareTag("Loot")) {
            // Loot
            value += c.GetComponent<LootValues>().value;
            c.gameObject.SetActive(false);
            inventoryText.text = "Value: " + value;
            c.GetComponent<LootValues>().updateInventory();
        }
    }
}
