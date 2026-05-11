using System.Collections;
using UnityEngine;

public class PalmaEmpaladora : MonoBehaviour
{
    private const int GOLPES_PARA_MORIR = 7;

    public float velocidad = 3f;
    public float tiempoEntreAtaques = 0.6f;

    private int _golpesRecibidos;
    private bool _estaAtacando;
    private Transform _jugador;

    private void Start()
    {
        _golpesRecibidos = 0;
        _estaAtacando = false;
        _jugador = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (_jugador == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            _jugador.position,
            velocidad * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (_estaAtacando) return;

        StartCoroutine(AtacarJugador(other));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        StopCoroutine(AtacarJugador(other));
        _estaAtacando = false;
    }

    private IEnumerator AtacarJugador(Collider2D other)
    {
        _estaAtacando = true;

        while (other != null && other.CompareTag("Player"))
        {
            vida v = other.GetComponent<vida>();
            if (v != null)
                v.TakeDamage();

            yield return new WaitForSeconds(tiempoEntreAtaques);
        }

        _estaAtacando = false;
    }

    public void RecibirGolpe()
    {
        _golpesRecibidos++;

        if (_golpesRecibidos >= GOLPES_PARA_MORIR)
            Destroy(gameObject);
    }
}