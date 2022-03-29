using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] int puntaje;
    [SerializeField] Text labelPuntaje;
    [SerializeField] Text labelVidas;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameEvent onGameOver;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver.SetActive(false);
        labelVidas.text = "Lives " + vidas.ToString();
    }

    public void GetPoints(int points) {
        puntaje += points;
        labelPuntaje.text = "Score: " + puntaje.ToString();
    }

    public void LoseLive() {
        vidas--;
        labelVidas.text = "Lives " + vidas.ToString();
        if (vidas <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        gameOver.SetActive(true);
        onGameOver.Raise();
    }
}
