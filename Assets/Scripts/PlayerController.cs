using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float impulsePlayer = 3f;
    [SerializeField] private float superSpeed = 8;
    private bool ignoreNextCollision;
    private Vector3 startPosition;
    [HideInInspector] public int perfectPass;
    private bool itsSuperSpeed;
    [SerializeField] private int perfectPassCount = 3;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)
        {
            return;
        }

        if (itsSuperSpeed && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }
        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                GameManager.singleton.RestartLevel();
            }
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulsePlayer, ForceMode.Impulse);
        ignoreNextCollision = true;
        Invoke("AllowNextCollision", 0.2f);
        perfectPass = 0;
        itsSuperSpeed = false;
    }

    private void Update()
    {
        if (perfectPass>=perfectPassCount && !itsSuperSpeed)
        {
            itsSuperSpeed = true;
            rb.AddForce(Vector3.down * superSpeed, ForceMode.Impulse);
        }
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
    }
}
