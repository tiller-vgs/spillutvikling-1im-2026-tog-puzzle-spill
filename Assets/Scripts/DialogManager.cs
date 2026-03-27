using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text text;
    public GameObject DialogSystem;

    void Start()
    {
        ShowMessage("Bob? Why are you running away? Wait for me! , What should I do?");
    }

    string[] words;
    int number;
    // This method is called to start a dialog sequence with the given message
    public void ShowMessage(string Message)
    {
        number = 0;

        words = Message.Split(',');
        DialogSystem.SetActive(true);
        Skip();
    }
    // This method is called when the player clicks the "Skip" button in the dialog UI
    public void Skip()
    {
        if (number < words.Length)
        {
            text.text = words[number];
            number += 1;
        }
        else
        {
            number = 0;
            DialogSystem.SetActive(false);
        }
        
    }
}
