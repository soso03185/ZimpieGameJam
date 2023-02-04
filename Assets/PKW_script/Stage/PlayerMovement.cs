using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Animator animator;

    [SerializeField] private Basket basket;
    [SerializeField] private bool isStuned = false;
    [SerializeField] float stunTime = 1.0f;
    [SerializeField] private KJH.KJH_Score Score;
    [SerializeField] private KJH_HpBar hpBar;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("IsMoving", false);
        SoundManager.Instance.SetSFXVolume(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStuned == true) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0) directionState = DirectionState.LeftDirection; 
        if (horizontalInput > 0) directionState = DirectionState.RightDirection;

        animator.SetBool("IsMoving", horizontalInput != 0.0f);

        rigidbody2D.velocity = new Vector2(horizontalInput * speed, rigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false;
            SoundManager.Instance.PlayVFX("jumpsfx");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bucket = Physics2D.OverlapBoxAll(RangePoint, size, 0);
            foreach (var v in bucket)
                if (v.CompareTag("Bucket"))
                {
                    Score.AddScore(basket.ItemCount);
                    basket.ItemCount = 0;
                    animator.SetTrigger("DoGoalin");
                    StartStopMoveCoroutine(0.5f);
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

    private Coroutine currentCoroutine = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            basket.ItemCount += 1;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Dust"))
        {
            hpBar.Half();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Stone"))
        {
            StartStopMoveCoroutine(stunTime);
            SoundManager.Instance.PlayVFX("hitsfx");
            animator.SetTrigger("DoHit");
        }
    }

    private void StartStopMoveCoroutine(float stopTime)
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(StunCooltime(stopTime));
    }

    IEnumerator StunCooltime(float stopTime)
    {
        isStuned = true;
        rigidbody2D.velocity = Vector3.zero;
        yield return new WaitForSeconds(stopTime);
        isStuned = false;
        currentCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(RangePoint, size);
    }
}
