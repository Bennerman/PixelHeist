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
    new Light2D light;
    Vector3 currentEulerAngles;
    float time;
    float spinTime = 5f;
    public bool playerSeen = false;
    bool spinClockwise = false;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        light = GetComponent<Light2D>();
        outerAngle = light.pointLightOuterAngle;
        outerRadius = light.pointLightOuterRadius;
        time = spinTime;
        
     
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newRotationAngles = transform.rotation.eulerAngles;

        time -= Time.deltaTime;

        if (time >= 0) {
            if (spinClockwise)
            {
                newRotationAngles.z +=  -10 * Time.deltaTime;
            }
            else
            {
                newRotationAngles.z += 10 * Time.deltaTime;
                

            }
            transform.rotation = Quaternion.Euler(newRotationAngles);


            /*
            Debug.Log(Vector3.Angle(flashLightDest, transform.rotation.eulerAngles) < 10);

            
            if (Vector3.Angle(flashLightDest, transform.rotation.eulerAngles) < 10)
            {
                randNum = Random.Range(0f, 90f);
                flashLightDest = new Vector3(0, 0, randNum);
            }
            */
            

        }
        else
        {
            time = spinTime;
            spinClockwise = !spinClockwise;
        }
         



    
        
       
        



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

        float rotation = transform.eulerAngles.z;
   
        Vector3 dir = target.position - enemy.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(angle < 0)
        {
            angle += 360;
        }
        
        
        float leftBound = (outerAngle / 2) + rotation + 90;
        float rightBound = rotation - (outerAngle / 2) + 90;

        if (angle < leftBound && angle > rightBound) {

            return true;
        }

        else
        {
            
            return false;
        }




    }

}
