using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public Text points;
    void Update()
    {
        //display points
        points.text = "Points = " + PlayerMovement.Instance.points.ToString() + " / " + PlayerMovement.Instance.maxPoints.ToString();
    }
}
