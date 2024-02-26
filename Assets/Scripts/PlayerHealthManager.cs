using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public float healthPoints = 20.0f;
    public RectTransform healthBar;
    public TextMeshProUGUI healthText;

    public void UpdateHealthBar() {
        // Check death
        if(healthPoints <= 0) {
            //TODO Death
            Application.LoadLevel(Application.loadedLevel); // Reload Level
            return;
        }

        // Update Bar
        Vector3 scale = healthBar.localScale;
        scale.x = healthPoints / 20.0f;
        healthBar.localScale = scale;

        // Update Text
        healthText.text = Mathf.Floor(healthPoints) + "/20";
    }

    public void ChangeHealth(float v) {
        healthPoints += v;
        UpdateHealthBar();
    }

    private void Start() { UpdateHealthBar(); }
}