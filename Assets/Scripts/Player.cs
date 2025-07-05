using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class Player : MonoBehaviour
{
    private static readonly int IsTapping = Animator.StringToHash("isTapping");
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem fart;
    [SerializeField] private UIHandler uiHandler;
    private Rigidbody2D rb;
    private SoundEffects soundEffects;
    private bool isPlayerAlive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundEffects = GetComponent<SoundEffects>();
        ResetPlayer();
    }
    
    void Update()
    {
        if (isPlayerAlive && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Debug.Log("Touch began");
            animator.SetBool(IsTapping, true);
            fart.Play();
            soundEffects.PlayRandom();
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void ResetPlayer()
    {
        animator.SetBool(IsTapping, false);
        animator.Play("Idle");
    }
    
    public void OnAnimationComplete()
    {
        animator.SetBool(IsTapping, false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("UpperWall"))
        {
            Invoke(nameof(GameOverCall),1f);
            isPlayerAlive = false;
        }
    }

    private void GameOverCall()
    {
        uiHandler.GameOver();
    }
}
