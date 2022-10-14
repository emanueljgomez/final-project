using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private string username;
    [SerializeField] private InputField input;
    [SerializeField] private Text playerNameText;

    void Start()
    {    
        input.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string arg0)
    {
        username = arg0;
        Debug.Log("(MenuControl.cs) Current Player: " + username);
        PlayerPrefs.SetString("PName", username);
        playerNameText.text = $"{username}";
    }
}
