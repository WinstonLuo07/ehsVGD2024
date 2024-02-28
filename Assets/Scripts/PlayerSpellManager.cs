using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerSpellManager : MonoBehaviour
{
    [HideInInspector] public enum Spells { 
        flameThrowerF, mollyF, 
        hurricaneW,
        shieldE, healE, rootInfectionE
    }
    public Spells[] spells = new Spells[3]{Spells.rootInfectionE, Spells.shieldE, Spells.healE};
    public float[] cooldown = new float[3]{0.5f, 30f, 5f};
    private bool[] locked = new bool[3]{false, false, false};

    public GameObject rootInfectionProjectile;
    public GameObject shield;
    public GameObject flameThrowerProjectile;
    public GameObject mollyProjectile;

    private void Update() {
        if(Input.GetAxisRaw("Fire3") > 0 && !locked[2]) { // Spell 3
            StartCoroutine(Cooldown(2));
            CastSpell(spells[2]);
        }
        if(Input.GetAxisRaw("Fire2") > 0 && !locked[1]) { // Spell 2
            StartCoroutine(Cooldown(1));
            CastSpell(spells[1]);
        }
        if(Input.GetAxisRaw("Fire1") > 0 && !locked[0]) { // Spell 1
            StartCoroutine(Cooldown(0));
            CastSpell(spells[0]);
        }
    }

    private void CastSpell(Spells s) {
        switch(s) {
            case Spells.healE: Heal(); break;
            case Spells.rootInfectionE: RootInfection(); break;
            case Spells.shieldE: Shield(); break;
            case Spells.flameThrowerF: FlameThrower(); break;
            case Spells.mollyF: Molly(); break;
            default: return;
        }
    }


    // Spells
    private void Heal() {
        PlayerHealthManager health = gameObject.GetComponent<PlayerHealthManager>();
        if(health.healthPoints > 16f) health.ChangeHealth(20f-health.healthPoints);
        else health.ChangeHealth(4f);
    }

    private void RootInfection() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(rootInfectionProjectile, transform.position + new Vector3(0.25f, 0.5f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }

    private void FlameThrower() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(flameThrowerProjectile, transform.position + new Vector3(0.25f, 0.5f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }

    private void Molly() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(mollyProjectile, transform.position + new Vector3(0.25f, 0.5f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }

    private void Shield() {
        GameObject s = Instantiate(shield, transform.position, transform.rotation);
        s.GetComponent<Shield>().player = this.gameObject;
    }

    // End Spells

    // Get string friendly name of spells
    public String getSpell(Spells s) {
        switch(s) {
        case Spells.flameThrowerF:
            return "Flame Thrower";
        case Spells.mollyF:
            return "Flame Molly";
        case Spells.hurricaneW:
            return "Hurricane";
        case Spells.shieldE:
            return "Shield";
        case Spells.healE:
            return "Heal";
        case Spells.rootInfectionE:
            return "Root Infection";
        default:
            return s.ToString();
        }
    }

    IEnumerator Cooldown(int index) {
        locked[index] = true;
        yield return new WaitForSeconds(cooldown[index]);
        locked[index] = false;
    }
}
