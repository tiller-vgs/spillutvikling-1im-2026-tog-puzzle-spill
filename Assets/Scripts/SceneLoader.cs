using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneLoaderScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the Space key is pressed down
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        // Load the scene by its name
        // Make sure the scene name is exactly as it appears in the Build Settings
        SceneManager.LoadScene("Main_menu");

        // Alternatively, load the scene by its build index (e.g., index 1)
        // SceneManager.LoadScene(1); 
    }
}
