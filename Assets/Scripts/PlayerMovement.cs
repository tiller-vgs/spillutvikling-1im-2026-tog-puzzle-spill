using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    SpriteRenderer sr;

    public InputActionAsset inputActions;

    public float speed = 5;
    public Animator anim;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        
        anim.SetFloat("horizontal", Mathf.Abs(moveX));

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        sr.flipX = moveX < 0 ? true : false;
    }
}
