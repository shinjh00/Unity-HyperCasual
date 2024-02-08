using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;

    [Header("Specs")]
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;

    [Header("Events")]
    public UnityEvent OnDied;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.right = rigid.velocity + Vector2.right * moveSpeed;
    }

    private void Jump()
    {
        // 힘에 의한 속도 변경 (가속방식) - 점점 속도 바뀜
        //rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        // 속도 자체를 변경 (속도지정방식) - 정해진 속도로 세팅
        rigid.velocity = Vector2.up * jumpSpeed;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Jump();
        }
    }

    private void Die()
    {
        animator.SetBool("Die", true);
        OnDied?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (장애물과 부딪히면)
        Die();
    }
}
