using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lock_check : MonoBehaviour
{
    public TMP_InputField Input_green;
    public TMP_InputField Input_gull;
    public TMP_InputField Input_white_circle;
    public TMP_InputField Input_blue;
    public GameObject Lock_Canvas;
    private string Right_lock_code = "96510";
    public string Bruker_input;
    // Start is called before the first frame update
    void Check()
    {

        Bruker_input= Input_green.text + Input_gull.text + Input_white_circle.text + Input_blue.text;

        if (Bruker_input == Right_lock_code) 
        {
            Debug.Log("Riktig kode");
            LoadNextScene();
        }
    }
    // This method is called to load the next scene when the correct code is entered
    public void LoadNextScene()
    {
        
        SceneManager.LoadScene("level_3_intro");

    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
}
