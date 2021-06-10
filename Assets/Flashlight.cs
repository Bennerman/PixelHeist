using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    Vector3 lightRotation; 
    public Transform target;
    public Transform enemy;
    public float outerAngle;
    public float outerRadius;
    Light2D light;
    Vector3 currentEulerAngles;
    public float rotationSpeed = 3f;
    float time = 0f;
    float randNum = 0f;

    public static bool playerSeen = false;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        light = GetComponent<Light2D>();
        outerAngle = light.pointLightOuterAngle;
        outerRadius = light.pointLightOuterRadius;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        randNum = Random.Range(-90f, 90f);
        
        
        
        while(time < 5) {
            transform.Rotate(0, 0, 10 * Time.deltaTime);

        }
        time = 0;




        if (checkPlayerSeen())
        {
            playerSeen = true;
        }
        else
        {
            playerSeen = false;
        }
    }




    

    bool checkPlayerSeen()
    {

        float rotation= transform.eulerAngles.z;
   
        Vector3 dir = target.position - enemy.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(angle < 0)
        {
            angle += 360;
        }
        
        
        float leftBound = (outerAngle / 2) + rotation + 90;
        float rightBound = rotation - (outerAngle / 2) + 90;
        //Debug.Log(rotation);
        //Debug.Log(angle + "vs: " + leftBound + " to" + rightBound);
        if (angle < leftBound && angle > rightBound) {

            return true;
        }

        else
        {
            
            return false;
        }




    }

}
