using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject DialogManager;
    public GameObject Trigger_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogManager.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogManager.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DialogManager.SetActive(false);
        Destroy(Trigger_text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
