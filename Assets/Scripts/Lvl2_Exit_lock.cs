using UnityEngine;

public class Lvl2_Exit_lock : MonoBehaviour
{
    public GameObject Lock_Canvas;

    public void Exit_Lock_B()
    {
        Lock_Canvas.SetActive(false);
    }
    // Update is called once per frame
}
