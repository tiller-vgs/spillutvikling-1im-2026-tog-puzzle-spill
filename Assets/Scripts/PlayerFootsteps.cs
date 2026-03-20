using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;

    [Header("Settings")]
    public float stepInterval = 0.35f; // How fast the footsteps play
    private float stepTimer;

    void Update()
    {
        // 1. Check if any movement keys are held down
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
                        Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        if (isMoving)
        {
            // 2. Count down the timer
            stepTimer -= Time.deltaTime;

            // 3. When timer hits zero, play sound and reset
            if (stepTimer <= 0f)
            {
                PlayRandomFootstep();
                stepTimer = stepInterval; // Reset the timer
            }
        }
        else
        {
            // Reset timer when you stop so the first step plays instantly next time
            stepTimer = 0f;
        }
    }

    void PlayRandomFootstep()
    {
        if (footstepSounds.Length == 0) return;

        int index = Random.Range(0, footstepSounds.Length);
        audioSource.pitch = Random.Range(0.85f, 1.15f); // Adds variety
        audioSource.PlayOneShot(footstepSounds[index]);
    }
}
