using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManagementSystem : MonoBehaviour
{
    public GameObject player;
    public int level = 0;
    public TextMeshProUGUI objective;
    private bool walkTutorial = false;
    private bool spellTutorial = false;

    [Header("Levels")]
    public GameObject level0Spawn;

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
    }

    IEnumerator SetText(string text, float wait) {
        yield return new WaitForSeconds(wait);
        objective.text = text;
    }
    
    private void OnTriggerEnter2D() {
        // SEND TO CAVES !!!
        switch(level){
            case 0: player.transform.position = level0Spawn.transform.position; 
                    StartCoroutine(SetText("Objective: Make your way to the exit. Beware of staligmites!", 0f)); break;
            default: return;
        }
    }
}
