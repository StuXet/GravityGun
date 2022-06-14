using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInstance : MonoBehaviour
{
    //Instance AddPoint and RemovePoints from static ScoreManager class
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddPoint();
        ScoreManager.instance.RemovePoints();
    }
}
