﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { Idle, Patrol, Chase, Attack}

public class Test_enemy : MonoBehaviour
{
    public EnemyStates state;
    public float health;



    //Moving
    public float moveSpeed;
    public float moveSpeedAttack;
    private bool movingRight;


    //Edge Detection
    public Transform groundDetection;
    public float edgeDistance;


    //Player Engagement
    private Transform target;
    public float engageDistance;
    public float followDistance;

    //Fighting
    public Transform player_detector;
    public LayerMask player;
    public float attackTimer;
    

    public float waitTimer = 5;
    public float patrolTimer = 8;
    //If statements met states: als player character in de buurt komt, gaat hij rennnen
    //In de state zelf, een if statement plaatsen



    // Start is called before the first frame update
    void Start()
    {
        state = EnemyStates.Idle;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();



    }


    void FixedUpdate()
    {
        ExecuteState();
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
            StartCoroutine(Death());

        }
    }

    private IEnumerator Death()
    {
        Debug.Log("Dood Animatie");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    void IdleState()
    {
        
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

        if (Vector2.Distance(transform.position, target.position) <= engageDistance)
        {
            SwitchState(EnemyStates.Attack);
        }
    }

    void PatrolState()
    {

        
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, edgeDistance);


        if (groundInfo.collider)
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

        if (Vector2.Distance(transform.position, target.position) <= engageDistance)
        {
            SwitchState(EnemyStates.Attack);
        }



    }

    void ChaseState()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeedAttack * Time.deltaTime);


        if (Vector2.Distance(transform.position, target.position) <= engageDistance)
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

        
        attackTimer -= Time.deltaTime;
        if (attackTimer < -0)
        {
            player_lives.health--;
            attackTimer = Random.Range(2, 3);

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




