using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movSpd = 0f;
    bool isMovRight = true;
    private Transform target;
    public float currX;

    public float walkSpeed;
    private float waitTime;
    public float startWaitTime;
    private float step;
    public Transform[] moveSpots;
    private int randomSpot;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        step = walkSpeed * Time.deltaTime;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        target = GetComponentInChildren<Flashlight>().target;
    }

    // Update is called once per frame
    void Update()
    {

        //Run at player
        if (GetComponentInChildren<Flashlight>().playerSeen)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movSpd * Time.deltaTime);


            if (currX > transform.position.x)
            {
                isMovRight = false;
            }
            else
            {
                isMovRight = true;
            }
            animator.SetBool("isMovingRight", isMovRight);
            animator.SetFloat("speed", Mathf.Abs(movSpd));

            currX = transform.position.x;
        }
        //Patrol
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, step);
            //Debug.Log(Vector2.Distance(transform.position, moveSpots[randomSpot].position));
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    int newSpot = Random.Range(0, moveSpots.Length);

                    while (newSpot == randomSpot)
                    {
                        newSpot = Random.Range(0, moveSpots.Length);
                    }
                    randomSpot = newSpot;

                    waitTime = startWaitTime;
                }
                else
                {
                    animator.SetBool("isMovingRight", isMovRight);
                    animator.SetFloat("speed", 0f);
                    waitTime -= Time.deltaTime;
                }

            }
            
        }
    }

        

        
}

