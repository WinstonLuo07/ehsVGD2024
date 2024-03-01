using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyMarketManager : MonoBehaviour
{
    public GameObject buyMenu;
    public int cost = 5;
    public TextMeshProUGUI[] spellText = new TextMeshProUGUI[3];
    private PlayerSpellManager psm;
    private PlayerLooting pl;

    private void Start() {
        buyMenu.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(c.CompareTag("Player") && Input.GetAxisRaw("Interact") > 0) {
            buyMenu.SetActive(true);
            psm = c.GetComponent<PlayerSpellManager>();
            pl = c.GetComponent<PlayerLooting>();

            spellText[0].text = psm.getSpell(psm.spells[0]);
            spellText[1].text = psm.getSpell(psm.spells[1]);
            spellText[2].text = psm.getSpell(psm.spells[2]);
        }
    }

    public void CloseScreen() {
        buyMenu.SetActive(false);
    }

    public void BuySpell() {
        if(psm == null || pl == null) return;
        if(pl.cash < cost) return;
        pl.cash -= cost;
        psm.GenerateSpell();

        spellText[0].text = psm.getSpell(psm.spells[0]);
        spellText[1].text = psm.getSpell(psm.spells[1]);
        spellText[2].text = psm.getSpell(psm.spells[2]);
    }
}
