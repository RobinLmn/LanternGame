using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the character 
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Movement(moveHorizontal * Time.fixedDeltaTime);
    }

    private void Movement(float horizontal)
    {
                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(horizontal * 10f, rb.velocity.y);
                // And then smoothing it out and applying it to the character
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

                // If the input is moving the player right and the player is facing left...
                if (horizontal > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (horizontal < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }

    }

    private void Flip()
    {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }
}
