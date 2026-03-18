using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    void OnTriggerEnter(Collider other) // Use OnTriggerEnter2D for 2D projects
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
