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
// Creates a simple main menu with two buttons: "Start" and "Exit". The Start button loads the scene with index 1 (in the Build Settings), while the Exit button quits the application.