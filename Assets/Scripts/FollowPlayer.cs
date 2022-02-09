using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float maxDistanceDelta = 0.2f;
    
    public Transform target;
    
    Vector3 defaultOffset;

    // Start is called before the first frame update
    void Start()
    {
        defaultOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + defaultOffset;
        targetPosition.x = transform.position.x;

        transform.position = targetPosition;
    }

}