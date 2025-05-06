using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator; // Animator of the prefab

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on player!");
        }

        if (animator == null)
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    void Update()
    {
        float verticalInput = Input.GetKey(KeyCode.UpArrow) ? 1f : 0f;

        // Trigger jump animation when moving up
        if (verticalInput > 0f)
        {
            animator.SetTrigger("Jumping_t");
        }
        else
        {
            animator.SetTrigger("Idle_t"); // Use a Trigger for idle animation
        }

        // Apply movement in the Rigidbody
        rb.velocity = new Vector2(0, verticalInput * moveSpeed);
    }
}
