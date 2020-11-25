using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    [SerializeField] private float outzoom;
	

    void Update() {
        transform.position = new Vector3(FollowTarget.transform.position.x + 0.2f,FollowTarget.transform.position.y,FollowTarget.transform.position.z - outzoom);
    }

}