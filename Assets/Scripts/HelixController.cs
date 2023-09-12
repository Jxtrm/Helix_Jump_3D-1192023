using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startPosition;
    public Transform topTransform; 
    public Transform goalTransform;
    public GameObject helixLevelPrefab;
    public List<Stage> allStages = new List<Stage>();
    public float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();

    private void Awake()
    {
        startPosition = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - goalTransform.localPosition.y + .1f;
        //LoadStage(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPosition = Input.mousePosition;
            if (lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }
            float distance = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up * distance);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPosition = Vector2.zero;
        }
    }

    public void LoadStage(int stageNumber)
    {

    }
}
