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

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MainManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(this.RestartGame);
    }

    public void RestartGame()
    {   
        PlayerPrefs.SetInt("PHealth", playerHealth);
        Debug.Log("(RestartButtonAction.cs) Juego reiniciado!");
        gameObject.SetActive(false);
        gameOverText.SetActive(false);
        endScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        // Hacer: desactivar cartel Game Over y volver a mostrar Pantalla de Inicio - reiniciar HP del jugador
    }
}
