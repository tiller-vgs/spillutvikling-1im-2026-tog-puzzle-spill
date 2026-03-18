using UnityEngine;

public class Drag2DLayer : MonoBehaviour
{
    public LayerMask draggableLayer; // Select your "Draggable" layer in the Inspector
    private GameObject selectedObject;
    private Vector3 offset;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Keep in 2D space

        if (Input.GetMouseButtonDown(0))
        {
            // Check if there's a 2D collider at the mouse position on the specific layer
            Collider2D targetObject = Physics2D.OverlapPoint(mousePos, draggableLayer);

            if (targetObject != null)
            {
                selectedObject = targetObject.gameObject;
                // Calculate offset so the object doesn't "snap" its center to the cursor
                offset = selectedObject.transform.position - mousePos;
            }
        }

        if (selectedObject != null)
        {
            // Move the object while following the mouse
            selectedObject.transform.position = mousePos + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }
    }
}

