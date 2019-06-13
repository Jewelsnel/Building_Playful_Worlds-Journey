using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroundEnemyStates { Idle, Patrol, Chase, Attack}

public class Ground_Enemy : MonoBehaviour
{
    private player_animator_controller playeranim;

    public GroundEnemyStates state;
    public float health;
    public Score score;


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

    //public bool hurtPlayer;

    //If statements met states: als player character in de buurt komt, gaat hij rennnen
    //In de state zelf, een if statement plaatsen



    // Start is called before the first frame update
    void Start()
    {
        state = GroundEnemyStates.Idle;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        playeranim = target.gameObject.GetComponent<player_animator_controller>();

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
            case GroundEnemyStates.Idle:
                IdleState();

                break;

            case GroundEnemyStates.Patrol:
                PatrolState();

                break;

            case GroundEnemyStates.Chase:
                ChaseState();

                break;

            case GroundEnemyStates.Attack:
                AttackState();

                break;



        }

    }

    public void SwitchState(GroundEnemyStates newState)
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
        Score.scoreAmount += 1;
    }


    void IdleState()
    {
        
        waitTimer -= Time.deltaTime;
        if (waitTimer < -0)
        {
            waitTimer = Random.Range(2, 3);
            SwitchState(GroundEnemyStates.Patrol);
        }

        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {
            SwitchState(GroundEnemyStates.Chase);
        }

        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) >= 2)
        {
            SwitchState(GroundEnemyStates.Attack);
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
            SwitchState(GroundEnemyStates.Idle);
            

        }

        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {
            SwitchState(GroundEnemyStates.Chase);
        }

        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) > 2)
        {
            SwitchState(GroundEnemyStates.Attack);
 

        }



    }

    void ChaseState()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeedAttack * Time.deltaTime);


        if (Vector2.Distance(transform.position, target.position) <= engageDistance && Vector2.Distance(transform.position, target.position) >= 2)
        {

            SwitchState(GroundEnemyStates.Attack);
            
        }

        if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
            SwitchState(GroundEnemyStates.Patrol);
        }
    }

    void AttackState()
    {
 

        attackTimer -= Time.deltaTime;
        if (attackTimer < -0)
        {
            Debug.Log("Valt aan");
            player_lives.health--;
            attackTimer = Random.Range(2, 3);
            playeranim.isHurt = true;

        }


        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position) <= followDistance)
        {

            SwitchState(GroundEnemyStates.Chase);
        }


        if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
            SwitchState(GroundEnemyStates.Patrol);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player_detector.position, engageDistance);

    }

}




