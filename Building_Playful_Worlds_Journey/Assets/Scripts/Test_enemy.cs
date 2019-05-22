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
    private bool movingRight;


    //Edge Detection
    public Transform groundDetection;
    public float edgeDistance;


    //Player Engagement
    private Transform target;
    public float engageDistance;
    public float followDistance;

    //Fighting
    public Transform attackPos;
    public float targetRange;
    public float activeFight;
    public float fightBreak;
    public LayerMask player;
    public float Invincibility = 2;
    public float attackTimer;

    //public float attackRange = 3f;

    public float waitTimer = 5;
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
        //CheckState();

        //StateEnum.Idle: light.color = Color.blue; break;
        //StateEnum.Attack: light.color = Color.blue; break;
        /*if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position)  < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) > engageDistance)
            {
                player_lives.health--;
            }
        }*/

        /*else if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, edgeDistance);


            if (groundInfo.collider == true)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        }*/
    }

    public void SwitchState(EnemyStates newState)
    {
        state = newState;
    }

    private bool CheckTarget(float followDistance) {
        return Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) < followDistance;
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
            waitTimer = Random.Range(3, 5);
            SwitchState(EnemyStates.Patrol);
        }
    }

    void PatrolState()
    {
       transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, edgeDistance);


        if (groundInfo.collider.tag == "Edge")
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

        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) < followDistance)
        {
            SwitchState(EnemyStates.Chase);
        }



    }

    void ChaseState()
    {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
 
        
       if (Vector2.Distance(transform.position, target.position) >= engageDistance)
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
            attackTimer = Random.Range(3, 5);
            
        }
        

        if (Vector2.Distance(transform.position, target.position) < engageDistance)
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, engageDistance);
    }
}