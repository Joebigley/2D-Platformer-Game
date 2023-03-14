using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
   

    public float offset;

    public GameObject projectile;
    //public GameObject shotEffect;
    public Transform shotPoint;
    

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    private Vector3 pos;
    private Vector2 dir;
    public Transform player;

    public int maxAngle;
    public int minAngle;

    private int Angle;



    private void Start()
    {
        player = transform.parent;

        Angle = 0;

        
    }

    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = pos - transform.position;
        dir.Normalize();
        Angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);


        if (player.localScale.x == 1)
        {
            Angle = Mathf.Clamp(Angle, minAngle, maxAngle);
            transform.localRotation = Quaternion.Euler(0f, 0f, Angle);
        }
        else
        {
            Angle = Mathf.Clamp(Angle, 180 - maxAngle, 180 - minAngle);
            transform.localRotation = Quaternion.Euler(0f, 0f, -Angle - 180f);
        }
    




       
        
            //CLAMP DO NOT REMOVE        
        //angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        //angle = Mathf.Clamp(angle, minAngle, maxAngle);
        //transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        


        



        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //Instantiate(shotPoint.position, Quaternion.identity);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                
    
            }
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }
    }

   
}

