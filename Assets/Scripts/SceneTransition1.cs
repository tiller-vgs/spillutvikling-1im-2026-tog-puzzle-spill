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

        _triggered = true;

        if (delay > 0f)
        {
            Invoke(nameof(LoadScene), delay);
        }
        else
        {
            LoadScene();
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
        }
    }
}
