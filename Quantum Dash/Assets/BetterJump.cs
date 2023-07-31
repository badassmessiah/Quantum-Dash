using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {




        if (rb.gravityScale < 0 && rb.velocity.y > 0)
        {

            rb.velocity -= (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;


        }
        else if (rb.gravityScale > 0 && rb.velocity.y < 0)
        {

            rb.velocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }



        else if (rb.velocity.y > 0 && !Input.GetMouseButtonDown(0))
        {
            rb.velocity += (lowJumpMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (rb.velocity.y < 0 && !Input.GetMouseButtonDown(0))
        {
            rb.velocity -= (lowJumpMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
    }

}
