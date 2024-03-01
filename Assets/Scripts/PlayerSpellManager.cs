using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerSpellManager : MonoBehaviour
{
    [HideInInspector] public enum Spells { 
        dashA,
        flameThrowerF, mollyF, 
        hurricaneW,
        shieldE, healE, rootInfectionE
    }

    public Spells[] spellSet = new Spells[]{Spells.dashA, Spells.flameThrowerF, Spells.mollyF, 
    Spells.hurricaneW, Spells.shieldE, Spells.healE, Spells.rootInfectionE};
    public float[] cooldownSet = new float[]{5f, 1.5f, 6f, 7.5f, 15f, 10f, 1.5f};
    public Sprite[] iconSet = new Sprite[7];
    public GameObject[] iconHUD = new GameObject[3];

    public Spells[] spells = new Spells[3]{Spells.rootInfectionE, Spells.shieldE, Spells.healE};
    public float[] cooldown = new float[3]{0.5f, 30f, 5f};
    private bool[] locked = new bool[3]{false, false, false};

    public GameObject rootInfectionProjectile;
    public GameObject shield;
    public GameObject flameThrowerProjectile;
    public GameObject mollyProjectile;
    public GameObject hurricaine;
    public float dashPower = 8f;
    public float dashTime;


    public Animator animator;

    private void Start() {
        GenerateSpell();
    }

    private void Update() {
        if(Input.GetAxisRaw("Fire3") > 0 && !locked[2]) { // Spell 3
            StartCoroutine(CastingAnimation(0.25f));
            StartCoroutine(Cooldown(2));
            CastSpell(spells[2]);
        }
        if(Input.GetAxisRaw("Fire2") > 0 && !locked[1]) { // Spell 2
            StartCoroutine(CastingAnimation(0.25f));
            StartCoroutine(Cooldown(1));
            CastSpell(spells[1]);
        }
        if(Input.GetAxisRaw("Fire1") > 0 && !locked[0]) { // Spell 1
            StartCoroutine(CastingAnimation(0.25f));
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
            case Spells.dashA: Dash(); break;
            case Spells.hurricaneW: Hurricaine(); break;
            default: return;
        }
    }

    public void GenerateSpell() {
        System.Random rand = new System.Random();
        int a = rand.Next(7), b = rand.Next(7), c = rand.Next(7);
        while(a==b || b==c || a==c) {
            a = rand.Next(7);
            b = rand.Next(7);
            c = rand.Next(7);
        }

        spells[0] = spellSet[a]; cooldown[0] = cooldownSet[a]; iconHUD[0].GetComponent<SpriteRenderer>().sprite = iconSet[a];
        spells[1] = spellSet[b]; cooldown[1] = cooldownSet[b]; iconHUD[1].GetComponent<SpriteRenderer>().sprite = iconSet[b];
        spells[2] = spellSet[c]; cooldown[2] = cooldownSet[c]; iconHUD[2].GetComponent<SpriteRenderer>().sprite = iconSet[c];
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
        Instantiate(rootInfectionProjectile, transform.position + new Vector3(0.1f, 0.2f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }

    private void FlameThrower() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(flameThrowerProjectile, transform.position + new Vector3(0.1f, 0.2f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }

    private void Molly() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(mollyProjectile, transform.position + new Vector3(0.1f, 0.2f, 0f), Quaternion.Euler(0f, 0f, rotZ-90));
    }
    
    private float playerSpeed = 2.5f;
    private void Dash() {
        playerSpeed = GetComponent<PlayerMovement>().moveSpeed;
        GetComponent<PlayerMovement>().moveSpeed = dashPower;
        Invoke("ResetSpeed", dashTime);
    }

    private void Hurricaine() {
        StartCoroutine(staggerHurricaine());
    }

    IEnumerator staggerHurricaine() {
        SpawnHurricaine(0.5f, 0.5f);
        yield return new WaitForSeconds(0.25f);
        SpawnHurricaine(0.75f, 0.4f);
        yield return new WaitForSeconds(0.25f);
        SpawnHurricaine(1f, .3f);
    }

    private void SpawnHurricaine(float distance, float degrees) {
        GameObject h = Instantiate(hurricaine, new Vector2(transform.position.x + distance, transform.position.y), transform.rotation);
        h.GetComponent<HurricaineManager>().player = gameObject;
        h.GetComponent<HurricaineManager>().degrees = degrees;
    }

    private void Shield() {
        GameObject s = Instantiate(shield, transform.position, transform.rotation);
        s.GetComponent<Shield>().player = this.gameObject;
    }

    // End Spells

    // Get string friendly name of spells
    public String getSpell(Spells s) {
        switch(s) {
            case Spells.dashA:
                return "Dash";
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
                return "Root Arrow";
            default:
                return s.ToString();
        }
    }

    IEnumerator Cooldown(int index) {
        locked[index] = true;
        yield return new WaitForSeconds(cooldown[index]);
        locked[index] = false;
    }

    IEnumerator CastingAnimation(float time) {
        animator.SetBool("Cast", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("Cast", false);
    }

    private void ResetSpeed() {
        GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
    }
}
