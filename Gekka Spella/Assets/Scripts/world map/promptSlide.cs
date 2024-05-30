using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;

public class promptSlide : MonoBehaviour
{
    [SerializeField] internal GameObject LocationOnScreen;
    [SerializeField] internal GameObject LocationOffScreen;
    [SerializeField] internal float speed;
    [SerializeField] internal GameObject prompt;
    internal Vector3 diff;
    internal bool onscreen = false;
    internal Vector3 direc;
    internal bool Onlocation;
    internal bool move;
    
    
    private void Update()
    {
     Onscreen();
     Move();
     There();
    }



    public void Onscreen()
    {
        if (onscreen == true)
        {

            diff = LocationOnScreen.transform.position - transform.position;

        }
        else
        {

            diff = LocationOffScreen.transform.position - transform.position;

        }
    }

    public void Move()
    {
            direc = diff.normalized;
            transform.position += direc * speed * Time.deltaTime;
    }

    public void There()
    {
        if (transform.position.x <= LocationOnScreen.transform.position.x && onscreen == true)
        {
            transform.position = LocationOnScreen.transform.position; 
        }else if (transform.position.x >= LocationOffScreen.transform.position.x && onscreen == false)
        {
            transform.position = LocationOffScreen.transform.position;
        }
    }
}
