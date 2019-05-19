using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class forest_enemies : MonoBehaviour
{

    public float health;


    public float moveSpeed;
    private bool movingRight;
    public Transform groundDetection;

    private Transform target;

    public float distance;

    public float engageDistance;

    public float followDistance;


    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > engageDistance && Vector2.Distance(transform.position, target.position)  < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, target.position) > followDistance)
        {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);

        if(groundInfo.collider == true)
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
        }




    }



    public void TakeDamage (float amount)
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

}
