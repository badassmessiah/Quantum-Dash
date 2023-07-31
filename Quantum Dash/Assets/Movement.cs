using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumps = 2;

    private int jumpsRemaining;

    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        jumpsRemaining = maxJumps;
    }

   
    void Update()
    {

        if (transform.position.x > 0.1 || transform.position.x < -0.1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.1f);
        }
       

        if (Input.GetMouseButtonDown(0) && jumpsRemaining > 0) // Check for left mouse button click
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Jump();
            }
            
            
        }
    }

    

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        jumpsRemaining--;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.layer == 3)
        {
            

            jumpsRemaining = maxJumps;
        }
    }

    
}
