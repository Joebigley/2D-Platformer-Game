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
    public Transform shotPointR;
    public Transform shotPointL;
    

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    private Vector3 pos;
    private Vector2 dir;
    public Transform player;

    public int maxAngle;
    public int minAngle;

    private int Angle;

    bool facingLeft = false;
    AudioSource audioSource;
    private void Start()
    {
        Angle = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PauseMenu.GameIsPaused == true || ID.GameIsPaused == true)
        {


        }
        else
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dir = pos - transform.position;
            dir.Normalize();

            //When the player faces left
            if (player.localScale.x == -1)
            {
                dir.x *= -1;
                facingLeft = true;
            }
            if (player.localScale.x == 1)
            {
                facingLeft = false;
            }

            Angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            Angle = Mathf.Clamp(Angle, minAngle, maxAngle);
            transform.localRotation = Quaternion.Euler(0f, 0f, Angle);


            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    //Instantiate(shotPoint.position, Quaternion.identity);
                    if (!facingLeft)
                    {
                        Instantiate(projectile, shotPointR.position, shotPointR.transform.rotation);
                        audioSource.Play();
                        
                    }
                    else if (facingLeft)
                    {

                        Instantiate(projectile, shotPointL.position, shotPointL.transform.rotation);
                        audioSource.Play();
                        
                    }

                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }


        }

    }
}