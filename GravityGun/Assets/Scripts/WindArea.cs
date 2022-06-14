using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    /* Add this script to game object with collider that have "Is Trigger" checked with tag "WindZone" 
    This script makes it possible to determine a wind area with force and direction to the boundaries of the collider of the object */
    public float strength;
    public Vector3 direction;
}
