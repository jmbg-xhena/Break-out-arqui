using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigi;
    Vector3 initPos;
    [SerializeField] GameEvent OnReset;
    // Start is called before the first frame update

    private void Awake()
    {
        initPos = transform.position;
    }

    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector3 playerPos) {
        if (rigi.velocity.y < -9.8f)
        {
            rigi.AddForce(new Vector2(-(transform.position.x - playerPos.x) - rigi.velocity.x, 9.8f));
        }
        else {
            rigi.AddForce(new Vector2(-(transform.position.x - playerPos.x) - rigi.velocity.x, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("floor")) {
            ResetBall();
        }
    }

    void ResetBall() {
        OnReset.Raise();
        transform.position = initPos;
        rigi.velocity = Vector2.zero;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
