using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Character : MonoBehaviour
{
    private Rigidbody2D rb => this.GetComponent<Rigidbody2D>();

    private float lastMovemntInput;

    public float Movemmentspeed = 5f;
    public float Jumpforce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(lastMovemntInput * Movemmentspeed, rb.linearVelocity.y);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        lastMovemntInput = context.ReadValue<float>();
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            Debug.Log("jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jumpforce);
        }
    }

    private bool IsGrounded()
    {

        RaycastHit2D hit;

         hit = Physics2D.Raycast(this.transform.position, Vector2.down, 7f, groundLayer);
        Debug.DrawRay(this.transform.position, Vector2.down,  Color.red, groundLayer);
        return hit;
      
    }
}
    

