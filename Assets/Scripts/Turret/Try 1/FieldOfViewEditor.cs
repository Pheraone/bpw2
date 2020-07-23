using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;

[CustomEditor (typeof (FieldOfView))]
public class ViewOfFieldEditior : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.viewRadius);
        Vector3 viewingAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewingAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewingAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewingAngleB * fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
