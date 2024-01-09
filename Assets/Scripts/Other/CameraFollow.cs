using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float yOffSet = 1f;
    [SerializeField] Transform followTarget;

    private void LateUpdate()
    {
        Vector3 newPos = new Vector3(followTarget.position.x, followTarget.position.y + yOffSet, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
