using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellMarketManager : MonoBehaviour 
{
    public TextMeshProUGUI cash;
    public GameObject notificationObject;
    public TextMeshProUGUI notification;
    public TextMeshProUGUI[] lootValues;
    private int cashValue;

    private void Start() {
        notificationObject.SetActive(false);
        foreach(TextMeshProUGUI lv in lootValues) {
            lv.text = "0";
        }
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(c.CompareTag("Player") && Input.GetAxisRaw("Interact") > 0) {
            int v = c.GetComponent<PlayerLooting>().value;
            cashValue += v;

            c.GetComponent<PlayerLooting>().ChangeValue(0);

            foreach(TextMeshProUGUI lv in lootValues) { 
                lv.text = "0";
            }

            cash.text = "$" + cashValue;
            notification.text = "+" + v;
            StartCoroutine(PlayNotification());
        }
    }

    IEnumerator PlayNotification() {
        notificationObject.SetActive(true);
        yield return new WaitForSeconds(1);
        notificationObject.SetActive(false);
    }
}
