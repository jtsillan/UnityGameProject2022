using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Kohde mitä kamera seuraa
    public Transform target;
    [SerializeField] float distance = 4.0f;
    [SerializeField] float height = 4.0f;

    // "Iskunvaimennus" nopeiden liikkeiden korjaamiseen
    [SerializeField] float damping = 5.0f;

    // Kuinka pehmeästi kamera seuraa
    [SerializeField] bool smoothRotation = true;
    [SerializeField] bool followBehind = true;
    [SerializeField] float rotationDamping = 10.0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition;

        if (followBehind)
        {
            wantedPosition = target.TransformPoint(0, height, -distance);
        }
        else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
        {
            transform.LookAt(target, target.up);
        }
    }
}
