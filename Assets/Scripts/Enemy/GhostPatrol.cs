using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    public Transform[] patrolPoint;
    private Transform playerTransform;
    private SpriteRenderer sr;

    public float speed;
    private int randomPiont;
    public float stopDistance;

    private bool relax = false;
    private bool pursuit = false;
    private bool goBack = false;


    void Start()
    {
        playerTransform = PlayerController.Singleton.transform;
        randomPiont = Random.Range(0, patrolPoint.Length);
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pursuit == false && Vector2.Distance(transform.position, playerTransform.position) > patrolPoint[randomPiont].position.x ||
            Vector2.Distance(transform.position, playerTransform.position) > patrolPoint[randomPiont].position.y)
        {
            relax = true;
        }

        if (Vector2.Distance(transform.position, playerTransform.position) < stopDistance)
        {
            pursuit = true;
            relax = false;
            goBack = false;

            if (transform.position.x > playerTransform.position.x && sr.flipX == false)
                sr.flipX = true;

            if (transform.position.x < playerTransform.position.x && sr.flipX == true)
                sr.flipX = false;

        }

        if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
        {
            goBack = true;
            pursuit = false;
        }

        if (relax)
        {
            Relax();
        }
        else if (pursuit)
        {
            Pursuit();
        }
        else if (goBack)
        {
            GoBack();
        }
    }

    /// <summary>
    /// Патрулирование территории
    /// </summary>
    private void Relax()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint[randomPiont].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoint[randomPiont].position) < 0.2f)
        {
            randomPiont = Random.Range(0, patrolPoint.Length);
        }
    }

    /// <summary>
    /// Преследование игрока
    /// </summary>
    private void Pursuit()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    /// <summary>
    /// Возврат на патрулируемую территорию
    /// </summary>
    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint[randomPiont].position, speed * Time.deltaTime);
    }
}
