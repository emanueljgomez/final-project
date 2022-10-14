using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    private Button button;
    private MainManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<MainManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(gameManager.StartGame); 
    }
}
