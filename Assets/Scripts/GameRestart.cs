using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class GameRestart : MonoBehaviour
{
    /// Restarts the currently active scene.
    public void RestartGame()
    {
        // Get the active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// Restart when pressing the 'R' key.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
