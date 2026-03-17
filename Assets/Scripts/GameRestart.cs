using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class GameRestart : MonoBehaviour
{
    /// <summary>
    /// Restarts the currently active scene.
    /// </summary>
    public void RestartGame()
    {
        // Get the active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// Optional: Restart when pressing the 'R' key.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
