using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonAction : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private Button button;
    [SerializeField] private MainManager gameManager;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MainManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(this.RestartGame);
    }

    public void RestartGame()
    {   
        PlayerPrefs.SetInt("PHealth", playerHealth);
        healthText = GameObject.FindGameObjectWithTag("healthText").GetComponent<Text>();
        healthText.text = $"{playerHealth}%";
        Debug.Log("(RestartButtonAction.cs) Juego reiniciado!");
        gameObject.SetActive(false);
        gameOverText.SetActive(false);
        endScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Score", 0);
        scoreText.text = $"Score: 0";
    }
}
