using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManagementSystem : MonoBehaviour
{
    public GameObject player;
    public float level = 0;
    public TextMeshProUGUI objective;
    private bool walkTutorial = false;
    private bool spellTutorial = false;
    private bool sellTutorial = false;
    private bool buyTutorial = false;

    [Header("Levels")]
    public GameObject level0Spawn;
    public GameObject level1Spawn;

    private void Start() {
        objective.text = "Use WASD or Arrow Keys to move around!";
    }
    private void Update() {
        if(!walkTutorial && (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0)) {
            walkTutorial = true;
            objective.text = "Spells are in the bottom left corner. Try them out!";
        }
        if(!spellTutorial && (Input.GetAxisRaw("Fire3") > 0)) {
            spellTutorial = true;
            objective.text = "Good job!";
            StartCoroutine(SetText("Spells can be used to fight enemies", 4f));
            StartCoroutine(SetText("Your spells have cooldowns, time your spells wisely!", 9f));
            StartCoroutine(SetText("Objective: Find the cave entrance", 13f));
        }
        if(!sellTutorial && level==1) {
            spellTutorial = true; walkTutorial = true; sellTutorial = true;
            StopAllCoroutines();
            StartCoroutine(SetText("Head over to the SELL both and hit E", 4f));
        }
        if(!buyTutorial && sellTutorial && Input.GetAxisRaw("Interact") > 0) {
            buyTutorial = true;
            StartCoroutine(SetText("Now you can reroll your current spells in the BUY both!", 0f));
            StartCoroutine(SetText("Try it out! Keep in mind each reroll costs $5", 4f));
            StartCoroutine(SetText("Awesome! You've got the basics down. Explore the caves to find the boss!", 8f));
            StartCoroutine(SetText("Remember, you might have to explore multilpe caves!", 12f));
        }
        if(buyTutorial) {
            StartCoroutine(SetText("Objective: Explore the caves", 16f));
        }
    }

    public IEnumerator SetText(string text, float wait) {
        yield return new WaitForSeconds(wait);
        objective.text = text;
    }
    
    private void OnTriggerEnter2D() {
        // SEND TO CAVES !!!
        switch(level){
            case 0: player.transform.position = level0Spawn.transform.position; 
                    StartCoroutine(SetText("Objective: Make your way to the exit. Beware of staligmites!", 0f));
                    break;
            case 1: player.transform.position = level1Spawn.transform.position;
                    StartCoroutine(SetText("Objective: Explore and collect the loot!", 0f));
                    break;
            default: return;
        }
    }
}
