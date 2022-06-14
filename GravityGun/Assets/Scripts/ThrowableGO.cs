using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script work on any game object that have a rigibody
public class ThrowableGO : MonoBehaviour
{
    private bool _inWindZone = false;
    private bool _inScoreZone = false;
    private bool _inRemoveScoreZone = false;
    private GameObject _windZone;
    private GameObject _scoreZone;
    private GameObject _RemoveScoreZone;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Game object get the force and direction from the wind zone
        if(_inWindZone) {
            rb.AddForce(_windZone.GetComponent<WindArea>().direction * _windZone.GetComponent<WindArea>().strength);
        }
    }

    //Trigger zones that detects coll between game objects
    void OnTriggerEnter(Collider coll) 
    {
        if(coll.gameObject.tag == "WindArea")
        {
            _windZone = coll.gameObject;
            _inWindZone = true;
        }

        if (coll.gameObject.tag == "ScoreZone")
        {
            _scoreZone = coll.gameObject;
            _inScoreZone = true;
            ScoreManager.instance.AddPoint();
            Destruction();
        }
        if (coll.gameObject.tag == "RemoveScoreZone")
        {
            _scoreZone = coll.gameObject;
            _inScoreZone = true;
            ScoreManager.instance.RemovePoints();
           Destruction();
        }
    }

    //Exit trigger zone to detect exit from zone
    void OnTriggerExit(Collider coll) {
        if(coll.gameObject.tag == "WindArea")
        {
            _inWindZone = false;
        }
        if (coll.gameObject.tag == "ScoreZone")
        {
            _inScoreZone = false;
        }
        if (coll.gameObject.tag == "RemovePointZone")
        {
            _inRemoveScoreZone = false;
        }
    }

    //Destroy game object
    void Destruction()
    {
        Destroy(this.gameObject);
    }
}