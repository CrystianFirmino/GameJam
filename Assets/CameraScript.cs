using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        Vector3 newPosition = player.transform.position + offset;
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }
}
