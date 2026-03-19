using UnityEngine;

public class LayerTouchDisappear : MonoBehaviour
{
    // You can set this name in the Inspector to match your target layer
    public string targetLayerName = "Obstacle";

    // Use OnTriggerEnter2D if one collider is a "Trigger"
    // Use OnCollisionEnter2D for physical "solid" impacts
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit is on the target layer
        if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            // Makes the sprite disappear
            Destroy(gameObject);
        }
    }
}
