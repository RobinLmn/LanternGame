using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingJumping : MonoBehaviour
{

    // Dashing

    private Rigidbody2D rb;
    private bool isDashing;
    public float dashspeed;

    // Double click

    private float last_tap;
    private float dash_delay = 0.5f;

    // Jump
    public float jump;
    private bool CanJump;
    public float JumpCoolDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDashing = false;
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                DoubleClick("Left");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DoubleClick("Right");
            }
        }

        if (Input.GetKey(KeyCode.Space) && CanJump)
        {
            rb.AddForce(new Vector2(0, 1) * jump);
            StartCoroutine(CoolDown(JumpCoolDown));
        }
    }

    IEnumerator CoolDown(float sec)
    {
        CanJump = false;
        Time.timeScale = 1;
        yield return new WaitForSeconds(sec);
        CanJump = true;
    }


    private void Dash(string directionDash)
    {
        if (directionDash == "Left")
            rb.velocity = Vector2.left * dashspeed;
        if (directionDash == "Right")
            rb.velocity = Vector2.right * dashspeed;
    }

    private void DoubleClick(string directiondash)
    {
        if ((Time.time - last_tap) < dash_delay)
        {
            Dash(directiondash);
        }
        last_tap = Time.time;

    }
}
