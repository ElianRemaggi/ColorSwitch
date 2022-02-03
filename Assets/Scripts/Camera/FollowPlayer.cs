using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransoform;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransoform.position.y > cameraTransform.position.y)
        {
            cameraTransform.position = new Vector3(transform.position.x, playerTransoform.position.y,cameraTransform.position.z);
        }
    }
}
