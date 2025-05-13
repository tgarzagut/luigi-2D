using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float waterResistance = 0.9f;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

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
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float verticalInput = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;
        currentVelocity = inputVector * moveSpeed;

        rb.velocity = currentVelocity * waterResistance;

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Jumping_t");
        }
    }
}
