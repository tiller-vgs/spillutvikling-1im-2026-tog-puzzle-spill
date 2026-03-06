using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public InputActionAsset inputActions;

    public float speed = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");


        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}
