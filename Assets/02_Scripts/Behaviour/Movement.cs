using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : Behaviour, IMoveable
{
    private Rigidbody rb;
    private Animator animator;

    [Header("Move Field")]
    [SerializeField] private float moveSpeed;
    private Vector2 _moveDir;

    [Header("Jump Field")]
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayerMask;

    [Header("RollField")]
    [SerializeField] private float rollPower;
    [SerializeField] private int RequiredStamina;
    private Vector3 rollVec;
    private bool isRolling;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        inputHandler.OnMoveEvent += GetMove;
        inputHandler.OnJumpEvent += Jump;
        inputHandler.OnRollEvent += Roll;
    }

    private void GetMove(Vector2 vector)
    {
        _moveDir = vector;
    }

    private void FixedUpdate()
    {
        Move(_moveDir);
    }

    public void Move(Vector2 dir)
    {
        //애니메이션
        animator.SetFloat("xAxis", dir.x);
        animator.SetFloat("yAxis", dir.y);
        //움직임 구현
        Vector3 moveDir = transform.forward * dir.y + transform.right * dir.x;
        moveDir *= moveSpeed;
        moveDir += new Vector3(0, rb.velocity.y, 0);

        if (isRolling && IsGrounded())
        {
            rb.velocity = rollVec;
        }
        else if(!isRolling)
        {
            rb.velocity = moveDir;
        }
        
    }


    public void Jump()
    {
        if(IsGrounded() && !isRolling)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Ray 확인 방법 더 효율적인거 찾아보기.
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    public void Roll()
    {
        //추후 구현
        if (CharacterManager.Instance.Player.Condition.Stamina.curValue < RequiredStamina || isRolling || !IsGrounded()) return;
        StartCoroutine(Rolling());
    }

    public IEnumerator Rolling()
    {
        isRolling = true;
        rb.velocity = Vector3.zero;
        animator.SetBool("Roll", isRolling);
        CharacterManager.Instance.Player.Condition.UseStamina(RequiredStamina);
        yield return new WaitForSeconds(0.2f);
        rollVec = transform.forward * rollPower;
        yield return new WaitForSeconds(0.4f);
        isRolling = false;
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Roll", isRolling);
    }
}