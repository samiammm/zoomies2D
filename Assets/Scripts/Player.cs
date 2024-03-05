using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jump;

    public LayerMask platform;
    public LayerMask deathBox;

    private Rigidbody2D rigidBody;
    private Collider2D playerCollider;
    private Animator animator;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;

    public GameManager gameManager;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }


    void Update()
    {

        bool dead = Physics2D.IsTouchingLayers(playerCollider, deathBox);
        if(dead) {
            GameOver();
            }

        if(transform.position.x > mileStoneCount) {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
            Debug.Log("M"+mileStone+", "+"MC"+mileStoneCount+", MS"+speed);
        }


        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, platform);
    
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            if(grounded) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jump);
                jumpSound.Play();
            }
        }

        animator.SetBool("Grounded", grounded);

        void GameOver() {
            gameManager.GameOver();
        }

    }
}
