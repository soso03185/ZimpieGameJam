using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public enum DirectionState
    {
        LeftDirection,
        RightDirection
    };

    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [Space()]
    [SerializeField] private float rangePointX;
    public Vector2 RangePoint { get
        {
            if (directionState == DirectionState.LeftDirection)
                return new Vector2(this.transform.position.x - rangePointX, this.transform.position.y);
            else
                return new Vector2(this.transform.position.x + rangePointX, this.transform.position.y);
        }
    }
    [SerializeField] Vector2 size = Vector2.one;
    private bool IsGrounded = false;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DirectionState directionState = DirectionState.LeftDirection;

    [SerializeField] private Basket basket;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0) directionState = DirectionState.LeftDirection;
        if (horizontalInput > 0) directionState = DirectionState.RightDirection;
        rigidbody2D.velocity = new Vector2(horizontalInput * speed, rigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bucket = Physics2D.OverlapBoxAll(RangePoint, size, 0);
            foreach (var v in bucket)
                if (v.CompareTag("Bucket"))
                {
                    //????
                    //gameManager.ScoreValue += 10;
                }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            basket.ItemCount += 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(RangePoint, size);
    }
}
