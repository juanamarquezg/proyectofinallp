using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public float tiempoTotal = 300f;

    private float _tiempoRestante;
    private bool _gameOverActivado;

    private void Start()
    {
        _tiempoRestante = tiempoTotal;
        _gameOverActivado = false;
    }

    private void Update()
    {
        if (_gameOverActivado) return;

        _tiempoRestante -= Time.deltaTime;

        if (_tiempoRestante <= 0)
        {
            _tiempoRestante = 0;
            _gameOverActivado = true;
            StartCoroutine(GameOverRoutine());
        }
    }

    private IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public float TiempoRestante => _tiempoRestante;
}
