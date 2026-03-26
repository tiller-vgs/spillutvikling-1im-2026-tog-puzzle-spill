using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
	public void StartButton()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}
