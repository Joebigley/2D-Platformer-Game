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
        

        Angle = 0;

        
    }

    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        dir = pos - transform.position;
        dir.Normalize();

        if (player.localScale.x == -1)
        {
            dir.x *= -1;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Angle = Mathf.Clamp(Angle, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(0f, 0f, Angle);




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

