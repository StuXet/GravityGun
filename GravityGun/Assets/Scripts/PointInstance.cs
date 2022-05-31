using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInstance : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddPoint();
    }
}
