using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIInside : MonoBehaviour
{

    [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] float sightRange;

    [SerializeField] Transform pointA;

    [SerializeField] Transform pointB;

    [SerializeField] Transform pointC;

    [SerializeField] float speed;

    [SerializeField] bool threePoints;

    [SerializeField] bool patrolling;

    bool pointACheck;

    bool pointBCheck;

    bool pointCCheck;

    bool back;

    bool playerInSightRange;

    float step;


    private void Start()
    {
        pointACheck = true;
        pointBCheck = false;
        pointCCheck = true;
        back = false;
    }


    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        step = speed * Time.deltaTime;

        if (!playerInSightRange)
        {
            Patrolling();
            CheckPoint();
        }

        if (playerInSightRange)
        {
            EndGame();
        }
    }

    void Patrolling()
    {
        if (patrolling)
        {
            if (!threePoints)
            {
                if (!pointACheck)
                {
                    transform.LookAt(pointA);
                    transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, step);

                }
                if (!pointBCheck)
                {
                    transform.LookAt(pointB);
                    transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, step);
                }
            }
            if (threePoints)
            {
                if (!pointACheck)
                {
                    transform.LookAt(pointA);
                    transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, step);

                }
                if (!pointBCheck)
                {
                    transform.LookAt(pointB);
                    transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, step);
                }
                if (!pointCCheck)
                {
                    transform.LookAt(pointC);
                    transform.position = Vector3.MoveTowards(transform.position, pointC.transform.position, step);
                }
            }
        }    
    }
    void CheckPoint()
    {
        if (patrolling)
        {
            if (!threePoints)
            {
                if (transform.position == pointA.transform.position)
                {
                    pointACheck = true;
                    pointBCheck = false;
                }
                if (transform.position == pointB.transform.position)
                {
                    pointBCheck = true;
                    pointACheck = false;
                }
            }
            if (threePoints)
            {
                if (transform.position == pointA.transform.position)
                {
                    pointACheck = true;
                    pointBCheck = false;
                    back = false;
                }
                if (transform.position == pointB.transform.position && !back)
                {
                    pointBCheck = true;
                    pointCCheck = false;
                }
                if (transform.position == pointC.transform.position)
                {
                    pointCCheck = true;
                    pointBCheck = false;
                    back = true;
                }
                if (transform.position == pointB.transform.position && back)
                {
                    pointBCheck = true;
                    pointACheck = false;
                }
            }
        }   
    }
    void EndGame()
    {
        GameObject.Find("Canvas").GetComponent<ButtonControl>().LoseInside();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

