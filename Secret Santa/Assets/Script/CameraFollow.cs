using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
	

    void Update() {
        transform.position = new Vector3(FollowTarget.transform.position.x + 0.8f,FollowTarget.transform.position.y,FollowTarget.transform.position.z - 8);
    }

}