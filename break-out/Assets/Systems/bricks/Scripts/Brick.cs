using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]private IntGameEvent onBrickDie;
    private static int puntosPorBrick = 10;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball")) {
            Die();
        }
    }

    private void Die() {
        Destroy(this.gameObject);
        onBrickDie.Raise(puntosPorBrick);
    }
}
