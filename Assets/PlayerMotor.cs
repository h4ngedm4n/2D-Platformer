using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    private bool canJump = true;
    public float jumpforce = 2;
    public float maxSpeed = 10;
    public float stoppingForce = 5;
    private int jumpCount = 0;
    public int maxJumps = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        HandleMaxSpeed();
        PlayerStopping();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void HandleMaxSpeed()
    {
        if (isDashing)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            jumpCount++;
            if (jumpCount >= maxJumps)
            {
                canJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        jumpCount = 0;  
    }

   private void OnDash()
    {
       isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0), ForceMode2D.Impulse);
    }

    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);
        isDashing = false;
    }



    public float dashForce = 10f;
   private bool isDashing = false;
    public float dashTime = 0.5f; 
  
    
}

