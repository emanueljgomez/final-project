using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneAsteroid : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private int score;
    [SerializeField] private int maxScore;
    [SerializeField] private int points;
    [SerializeField] private Text scoreText;    
    [SerializeField] private Text maxScoreText;
    [SerializeField] private string username;
    [SerializeField] private GameObject otherGO;
    
    private void OnTriggerEnter(Collider other) {

        scoreText = GameObject.FindGameObjectWithTag("ShowScore").GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");
        maxScore = PlayerPrefs.GetInt("MaxScore");
        username = PlayerPrefs.GetString("PName");
        maxScoreText = GameObject.FindGameObjectWithTag("ShowMaxScore").GetComponent<Text>();

        if (other.gameObject.tag == "Asteroid1" | other.gameObject.tag == "Asteroid2" | other.gameObject.tag == "Asteroid3")
        {
            Debug.Log("Two asteroids have collisioned!");
        } else if (other.gameObject.tag == "Player" && (gameObject.tag == "Asteroid1" | gameObject.tag == "Asteroid5") )
        {   
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -20; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 1 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && gameObject.tag == "Asteroid2" )
        {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -30; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 2 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player" && (gameObject.tag == "Asteroid3" | gameObject.tag == "Asteroid4") )
        {
            // Using PlayerPrefs to track Player's Health
            playerHealth = PlayerPrefs.GetInt("PHealth");
            playerHealth = playerHealth -10; // Value changes depending on asteroid type
            PlayerPrefs.SetInt("PHealth", playerHealth);
            // ----------
            Debug.Log("Type 3 Asteroid impact detected! -- Hull integrity: " + playerHealth);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "PlayerProjectile" && (gameObject.tag == "Asteroid3" | gameObject.tag == "Asteroid4") )
            {
                points = 10;
                otherGO = other.gameObject;
                handleDestroy();

            }  else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid2" )
            {
                points = 30;
                otherGO = other.gameObject;
                handleDestroy();

            } else if (other.gameObject.tag == "PlayerProjectile" && (gameObject.tag == "Asteroid1" | gameObject.tag == "Asteroid5") )
            {
                points = 20;
                otherGO = other.gameObject;
                handleDestroy();
            } else if (other.gameObject.tag == "PlayerProjectile" && gameObject.tag == "Asteroid4B" )
            {
                points = 5;
                otherGO = other.gameObject;
                handleDestroy();
            }         
        }
            

    private void checkMaxScore() {
        if (score > maxScore) {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore", maxScore);
            PlayerPrefs.SetString("Champion", username);
            maxScoreText.text = $"{username} - {maxScore}";            
        }
    }

    public virtual void handleDestroy() {
        score = score + points; // Value changes depending on asteroid type
        PlayerPrefs.SetInt("Score", score);
        // ----------
        scoreText.text = $"Score: {score}";
        Debug.Log("[ " + gameObject.tag + " ] destroyed - Score updated: " + score);
        checkMaxScore();
        Destroy(otherGO);
        Destroy(gameObject);
    }

}
