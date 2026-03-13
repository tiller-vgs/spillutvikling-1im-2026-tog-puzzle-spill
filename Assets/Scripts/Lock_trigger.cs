using UnityEngine;

public class Lock_trigger : MonoBehaviour
{
    public GameObject Lock_Canvas;
    public GameObject Lock_Trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lock_Canvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Lock_Canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Lock_Canvas.SetActive(false);
    }
}
