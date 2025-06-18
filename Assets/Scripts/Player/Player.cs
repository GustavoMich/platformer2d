using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation setup")]
    /*public float JumpScaleY = 1.5f;
    public float JumpScaleX = 0.7f;
    public float animationDuration = .3f;*/
    public Ease ease = Ease.OutBack;
    public SOFloat soJumpScaleY;
    public SOFloat soJumpScaleX;
    public SOFloat soAnimationDuration;


    [Header("Animation player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public string boolJump = "Jump";
    public string boolJumpDown = "JumpDown";
    public Animator animator;
    public float playerSwipeDuration = .1f;


    private float _currentSpeed;


    private void Awake()
    {
       if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        animator.SetTrigger(triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
           animator.speed = 2;

        }
        else
        {
            _currentSpeed = speed;
           animator.speed = 1;

        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            animator.SetBool(boolJump, true);


            DOTween.Kill(myRigidbody.transform);

        }
        else
        {
            animator.SetBool(boolJump, false);
            animator.SetBool(boolJumpDown, true);

        }

    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soJumpScaleY.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(soJumpScaleX.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
