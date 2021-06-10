using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movSpd = 40f;
    public float xMov = 0f;
    public float yMov = 0f;
    bool isMovRight = true;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         xMov = Input.GetAxis("Horizontal");
         yMov = Input.GetAxis("Vertical");

        if(xMov < 0)
        {
            isMovRight = false;
        }
        else
        {
            isMovRight = true;
        }
        Vector3 move = new Vector3(xMov, yMov, 0);
        
        move = move.normalized;

        transform.position += move * Time.deltaTime * movSpd;
   
        animator.SetFloat("speed", Mathf.Abs(movSpd * move.magnitude));

        animator.SetBool("isMovingRight", isMovRight);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Painting hit");

        
    }
}
