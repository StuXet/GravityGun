using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 3f, throwForce = 20f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;

    void Update()
    {
        Debug.Log(cam.transform.forward);
        GrabbingBehavior();
        ThrowForce();
        
    }

    //Updates the force in throw force
    void ThrowForce()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            throwForce++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            throwForce--;
        }
    }

    /* Get if player grabbed the game object
      Updates the game object position with the camera direction
      If player throw the game object it disable his kinematic
      And flew in the direction of the camera looking at it with the selected force */
    void GrabbingBehavior()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(objectHolder.transform.position);

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }
        //If the player grab the object it makes the object kinematic to not be affected by the game physics
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}
