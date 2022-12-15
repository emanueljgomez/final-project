using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneAsteroidSpecial : DeathZoneAsteroid // INHERITANCE
{   
    [SerializeField] private GameObject miniAsteroid;

    void Start()
    {
        playerHealth = PlayerPrefs.GetInt("PHealth");
        healthText = GameObject.FindGameObjectWithTag("healthText").GetComponent<Text>();
        statusText = GameObject.FindGameObjectWithTag("statusText").GetComponent<Text>();
        Invoke("updateStatus", 5.0f);
    }

    // Polymorphism: handleDestroy() from DeathZoneAsteroid.cs base functionality is extended
    public override void handleDestroy() { // POLYMORPHISM
        
        if (gameObject.tag == "Asteroid5" && playerHealth < 100) {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth +10; // Restores player health upon being destroyed
            if (playerHealth > 100) {
                playerHealth = 100;
            }
            PlayerPrefs.SetInt("PHealth", playerHealth);
            Debug.Log("Green Asteroid destroyed! [ +10 Health ] -- Hull integrity: " + playerHealth);
            statusText.text = "Green Asteroid destroyed!" + "\n" + "[ +10 Health ]";
            statusText.GetComponent<Text>().color = Color.green;
            healthText.text = $"{playerHealth}%";
        } else if (gameObject.tag == "Asteroid4") {
            Debug.Log("Red Asteroid impact detected!");
            Instantiate(miniAsteroid, transform.position, miniAsteroid.transform.rotation);
        } else if (gameObject.tag == "Asteroid4B") {
            Debug.Log("Mini Asteroid destroyed!");
        }

        base.handleDestroy();
    }  

    void updateStatus()
    {   

        if (!(statusText.text == "---")) {
            statusText.text = "---";
            statusText.GetComponent<Text>().color = Color.white;
        }

    }



}
