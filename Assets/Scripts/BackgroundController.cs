using System.Linq;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public Transform cam;
    [Range(0f, 1f)]
    public float parallaxEffect = 0.5f;
    public float scrollSpeed = 0f;
    public Transform[] parts;

    private float[] widths;
    private float[] partStartX;
    private float scroll;

    void Start()
    {

        parts = parts.OrderBy(p => p.position.x).ToArray();


        widths = new float[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            var sr = parts[i].GetComponent<SpriteRenderer>();
            if (sr == null)
            {
                enabled = false;
                return;
            }

            widths[i] = sr.bounds.size.x;
        }

        partStartX = new float[parts.Length];

        float initialParallaxOffset = cam.position.x * parallaxEffect;
        partStartX[0] = parts[0].position.x - initialParallaxOffset;
        parts[0].position = new Vector3(partStartX[0] + initialParallaxOffset, parts[0].position.y, parts[0].position.z);

        for (int i = 1; i < parts.Length; i++)
        {
            partStartX[i] = partStartX[i - 1] + widths[i - 1];
            parts[i].position = new Vector3(partStartX[i] + initialParallaxOffset, parts[i].position.y, parts[i].position.z);
        }
    }

    void LateUpdate()
    {

        scroll += scrollSpeed * Time.deltaTime;

        float parallaxOffset = cam.position.x * parallaxEffect;


        for (int i = 0; i < parts.Length; i++)
        {
            float targetX = partStartX[i] + parallaxOffset - scroll;
            parts[i].position = new Vector3(targetX, parts[i].position.y, parts[i].position.z);
        }
        for (int i = 0; i < parts.Length; i++)
        {
            float targetX = partStartX[i] + parallaxOffset - scroll;


            if (targetX + widths[i] < cam.position.x - widths[i])
            {

                float maxEnd = float.MinValue;
                for (int j = 0; j < partStartX.Length; j++)
                    maxEnd = Mathf.Max(maxEnd, partStartX[j] + widths[j]);

                partStartX[i] = maxEnd;
                parts[i].position = new Vector3(partStartX[i] + parallaxOffset - scroll, parts[i].position.y, parts[i].position.z);
            }

            else if (targetX > cam.position.x + widths[i])
            {
                float minStart = float.MaxValue;
                for (int j = 0; j < partStartX.Length; j++)
                    minStart = Mathf.Min(minStart, partStartX[j]);

                partStartX[i] = minStart - widths[i];
                parts[i].position = new Vector3(partStartX[i] + parallaxOffset - scroll, parts[i].position.y, parts[i].position.z);
            }
        }
    }
}
