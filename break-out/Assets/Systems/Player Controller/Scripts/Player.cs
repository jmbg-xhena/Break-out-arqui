using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float launchForce;

    [SerializeField]
    private IntGameEvent onPointsEarned;
    [SerializeField]
    private GameEvent onPlayerDied;
    [SerializeField]
    private Vector3GameEvent onBallLaunched;

    private Vector3 movement;
    private int points;

    private Rigidbody2D rigi;
    [SerializeField] private float t = 0;
    [SerializeField] private bool moving = false;
    Vector3 move;

    Vector3 initPos;

    private void Awake()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        initPos = transform.position;
    }

    public void Move(Vector3 direction)
    {
        moving = true;
        movement = direction;
    }

    public void Stop()
    {
        t = 0;
        movement = Vector2.zero;
        moving = false;
    }

    private void Update()
    {
        if (moving)
        {
            move = movement * speed;
            rigi.velocity = move;
        }
        else {
            if (t < 0.1) {
                t += Time.deltaTime;
            }
            move = Vector2.Lerp(rigi.velocity, Vector2.zero,t);
            rigi.velocity = move;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) {
            onBallLaunched.Raise(transform.position*launchForce);
        }
    }

    public void ResetPlayer()
    {
        transform.position = initPos;
        rigi.velocity = Vector2.zero;
    }
}