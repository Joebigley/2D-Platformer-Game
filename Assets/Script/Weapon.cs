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
    private Transform player;

    public int maxAngle;
    public int minAngle;

    private int angle;



    private void Start()
    {
        player = transform.parent;

        angle = 90;
    }

    private void Update()
    {
        // Handles the weapon rotation
       
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);



        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        dir = pos - transform.position;
        dir.Normalize();

        if (player.localScale.x == -1)
        {
            dir.x *= -1;
        }

        angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);


        



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

    private GameObject Instantiate(Vector3 position, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}

