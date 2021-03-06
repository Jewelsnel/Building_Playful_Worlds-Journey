﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyStates { Idle, Patrol, Chase, Attack}

public class Test_enemy : MonoBehaviour
{
    //Animation
    private Animator enemyAnim;
    private player_animator_controller playeranim;
    private SpriteRenderer enemy;


    public EnemyStates state;
    public float health;
    public Score score;


    //Moving
    public float moveSpeed;
    public float moveSpeedAttack;
    private bool movingRight;
    private Rigidbody2D rb;


    //Edge Detection
    public Transform groundDetection;
    public float edgeDistance;
    public float wallDistance;


    //Player Engagement
    private Transform target;
    public float engageDistance;
    public float followDistance;

    //Fighting
    public Transform player_detector;
    public LayerMask player;
    public float attackTimer;


    //Timers
    public float waitTimer = 5;
    public float patrolTimer = 8;




    //If statements met states: als player character in de buurt komt, gaat hij rennnen
    //In de state zelf, een if statement plaatsen



    // Start is called before the first frame update
    void Start()
    {
        state = EnemyStates.Idle;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        enemyAnim = GetComponent<Animator>();
        playeranim = target.gameObject.GetComponent<player_animator_controller>();
        enemy = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }



    void FixedUpdate()
    {

       ExecuteState();


        if (rb.position.y < -100f)
        {
            Death();
        }
    }


    // Update is called once per frame
    void ExecuteState()
    {


        switch (state)
        {
            case EnemyStates.Idle:
                IdleState();

                break;

            case EnemyStates.Patrol:
                PatrolState();

                break;

            case EnemyStates.Chase:
                ChaseState();

                break;

            case EnemyStates.Attack:
                AttackState();

                break;
        }

    }

    public void SwitchState(EnemyStates newState)
    {
        state = newState;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            enemyAnim.SetTrigger("death");
            enemyAnim.SetBool("isAttacking", false);
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isChasing", false);

        }
    }


    public void Death()
    {
        Destroy(gameObject);  
        Score.scoreAmount += 1;
    }




    void IdleState()
    {
        enemyAnim.SetBool("isAttacking", false);
        enemyAnim.SetBool("isWalking", false);
        enemyAnim.SetBool("isChasing", false);


        waitTimer -= Time.deltaTime;
        if (waitTimer < -0)
        {
            waitTimer = Random.Range(2, 3);
            SwitchState(EnemyStates.Patrol);
        }

        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {
            SwitchState(EnemyStates.Chase);
        }

        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) >= 2)
        {
            SwitchState(EnemyStates.Attack);
        }
    }

    void PatrolState()
    {
  
        enemyAnim.SetBool("isWalking", true);
        enemyAnim.SetBool("isChasing", false);
        enemyAnim.SetBool("isAttacking", false);



        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, edgeDistance);

        RaycastHit2D EdgeInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, wallDistance);


        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            
        }

        else if (EdgeInfo.collider)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }

        patrolTimer -= Time.deltaTime;
        if (patrolTimer < -0)
        {
            patrolTimer = Random.Range(5, 8);
            SwitchState(EnemyStates.Idle);
            

        }

        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {
            SwitchState(EnemyStates.Chase);
        }

        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) > 2)
        {
            SwitchState(EnemyStates.Attack);
 

        }



    }

    void ChaseState()
    {
        enemyAnim.SetBool("isChasing", true);
        enemyAnim.SetBool("isWalking", false);
        enemyAnim.SetBool("isAttacking", false);


        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeedAttack * Time.deltaTime);

        if (target.position.x > transform.position.x)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (target.position.x < transform.position.x)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) >= 2)
        {

            SwitchState(EnemyStates.Attack);
            
        }

        if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
            SwitchState(EnemyStates.Patrol);
        }

        



    }

    void AttackState()
    {


        enemyAnim.SetBool("isAttacking", true);
        enemyAnim.SetBool("isWalking", false);
        enemyAnim.SetBool("isChasing", false);

        

            attackTimer -= Time.deltaTime;
            if (attackTimer < -0)
            {

                
                attackTimer = Random.Range(4, 6);
                player_lives.health--;
                playeranim.isHurt = true;

            }




        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {

            SwitchState(EnemyStates.Chase);
        }


        if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
            SwitchState(EnemyStates.Patrol);
        }
    }





    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player_detector.position, engageDistance);

    }



}





