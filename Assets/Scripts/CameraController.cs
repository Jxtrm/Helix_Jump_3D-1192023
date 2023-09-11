using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 actualPos = transform.position;
        actualPos.y = player.transform.position.y + offset;
        transform.position = actualPos;
    }
}
