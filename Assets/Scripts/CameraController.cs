using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Target;
    public Vector3 Offset;
    public float LerpValue;

    void LateUpdate()
    {
        Vector3 destinationPosition = Target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, destinationPosition, LerpValue);
    }
}
