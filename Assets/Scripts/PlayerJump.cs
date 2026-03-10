using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool grounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 6f;

    [SerializeField] private Vector2 boxSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -0.5f);
    [SerializeField] private LayerMask groundLayer;
    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

   
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Vector2 origin = (Vector2)transform.position + boxOffset;
        grounded = Physics2D.OverlapBox(origin, boxSize, 0f, groundLayer) != null;
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((Vector3)((Vector2)transform.position + boxOffset), boxSize);
    }
}
