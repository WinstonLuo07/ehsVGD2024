using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public float cooldown = 0.5f;
    private bool paused = false;

    private void Start() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            toggle();
        }
    }

    public void toggle() {
        if(!paused) {
            Time.timeScale = 0; // TODO: Lerp if want
            pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1; // TODO: Lerp if want
            pauseMenu.SetActive(false);
        }
        paused = !paused;
    }
}
