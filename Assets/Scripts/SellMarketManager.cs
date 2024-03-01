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
    public float cooldown = 0.25f;
    public bool locked = false;

    private void Start() {
        notificationObject.SetActive(false);
        foreach(TextMeshProUGUI lv in lootValues) {
            lv.text = "0";
        }
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(!locked && c.CompareTag("Player") && Input.GetAxisRaw("Interact") > 0) {
            StartCoroutine(CoolDown());
            int v = c.GetComponent<PlayerLooting>().value;
            notification.text = "+$" + v;
            cashValue += v;

            c.GetComponent<PlayerLooting>().ChangeValue(0);

            foreach(TextMeshProUGUI lv in lootValues) { 
                lv.text = "0";
            }

            cash.text = "$" + cashValue;
            c.GetComponent<PlayerLooting>().cash = cashValue;
            StartCoroutine(PlayNotification());
        }
    }

    IEnumerator PlayNotification() {
        notificationObject.SetActive(true);
        yield return new WaitForSeconds(1);
        notificationObject.SetActive(false);
    }

    IEnumerator CoolDown() {
        locked = true;
        yield return new WaitForSeconds(cooldown);
        locked = false;
    }
}
