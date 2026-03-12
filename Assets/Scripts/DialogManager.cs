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

    public void ShowMessage(string Message)
    {
        number = 0;

        words = Message.Split(',');
        DialogSystem.SetActive(true);
        Skip();
    }

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
