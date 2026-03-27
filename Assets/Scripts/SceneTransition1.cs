using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneTransition1 : MonoBehaviour
{
    [Header("Scene transition")]
    [Tooltip("Name of the scene to load. Must be added to Build Settings.")]
    [SerializeField] private string sceneName = "level2";

    [Tooltip("Optional delay (seconds) before loading the scene.")]
    [SerializeField] private float delay = 0f;

    [Tooltip("Use asynchronous scene loading for smoother transitions.")]
    [SerializeField] private bool useAsync = true;
    
    private bool _triggered;

    private void Reset()
    {
        // When attaching this component in the editor, prefer the collider be a trigger.
        var col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_triggered) return;
        if (!other.CompareTag("Player")) return;
        // Checks if the colliding object has the "Player" tag. If not, it ignores the collision.
        _triggered = true;

        if (delay > 0f)
        {
            Invoke(nameof(LoadScene), delay);
        }
        else
        {
            LoadScene();
            // Prevents multiple triggers by setting _triggered to true, ensuring the scene loads only once per collision.
        }
    }

    private void LoadScene()
    {
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.LogWarning($"{nameof(SceneTransition1)}: sceneName is empty - cannot load scene.");
            return;
        }

        if (useAsync)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            // Loads the specified scene either asynchronously or synchronously based on the useAsync flag. Asynchronous loading allows for smoother transitions without freezing the game.
        }
    }
}
