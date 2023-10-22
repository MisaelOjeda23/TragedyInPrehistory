using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillyMovement3 : MonoBehaviour
{
    public float runSpeed = 3f;
    float moveHorizontal;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MomeAxisHorizontal();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PowerUp"))
        {
            runSpeed = runSpeed + 1.5f;
            Destroy(collision.gameObject);
        }
    }

    public void MomeAxisHorizontal()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal*runSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    public void Flip()
    {
        if (moveHorizontal > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(2f, 2f, 1);
        }
        else if (moveHorizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 1);
        }

    }
}
