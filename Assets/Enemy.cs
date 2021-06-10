using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movSpd = 40f;
    bool isMovRight = true;
    private Transform target;
    public float currX;
    

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, target.position, movSpd * Time.deltaTime);
        

        if(currX > transform.position.x)
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
}
