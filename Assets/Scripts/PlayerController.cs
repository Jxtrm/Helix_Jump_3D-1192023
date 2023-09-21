using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float impulsePlayer = 3f;
    [SerializeField] private float superSpeed = 8;
    [SerializeField] private int perfectPassCount = 3;
    [HideInInspector] public int perfectPass;
    private bool ignoreNextCollision;
    private Vector3 startPosition;
    private bool itsSuperSpeed;
    public GameObject splash;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AddSplash(collision);
        if (ignoreNextCollision)
        {
            return;
        }

        if (itsSuperSpeed && !collision.transform.GetComponent<GoalController>())
        {
            GameManager.singleton.AddScore(1);
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

    public void AddSplash(Collision collision)
    {
        GameObject newSplash;
        newSplash = Instantiate(splash);
        newSplash.transform.SetParent(collision.transform);
        newSplash.transform.position = new Vector3(transform.position.x, transform.position.y - 0.11f, transform.position.z);
        Destroy(newSplash, 3f);
    }
}