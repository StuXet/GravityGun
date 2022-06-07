using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool inWindZone = false;
    public bool inScoreZone = false;
    public bool inRemoveScoreZone = false;
    public GameObject windZone;
    public GameObject scoreZone;
    public GameObject RemoveScoreZone;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Game object get the force from the wind zone
        if(inWindZone) {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    //Trigger zone that detects coll between game objects
    void OnTriggerEnter(Collider coll) 
    {
        if(coll.gameObject.tag == "WindArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }

        if (coll.gameObject.tag == "ScoreZone")
        {
            scoreZone = coll.gameObject;
            inScoreZone = true;
            ScoreManager.instance.AddPoint();
            Destruction();
        }
        if (coll.gameObject.tag == "RemoveScoreZone")
        {
            scoreZone = coll.gameObject;
            inScoreZone = true;
            ScoreManager.instance.RemovePoints();
           Destruction();
        }
    }

    void OnTriggerExit(Collider coll) {
        if(coll.gameObject.tag == "WindArea")
        {
            inWindZone = false;
        }

        if (coll.gameObject.tag == "ScoreZone")
        {
            inScoreZone = false;
        }
        if (coll.gameObject.tag == "RemovePointZone")
        {
            inRemoveScoreZone = false;
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}