using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private const int GOLPES_PARA_MORIR = 4;

    public float velocidad = 1.5f;
    public float tiempoEntreAtaques = 1.2f;

    private int golpesRecibidos;
    private bool estaAtacando;
    private Transform jugador;
    private Coroutine corrutinaAtaque;

    private void Start()
    {
        golpesRecibidos = 0;
        estaAtacando = false;
        jugador = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (jugador == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            jugador.position,
            velocidad * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (estaAtacando) return;

        corrutinaAtaque = StartCoroutine(AtacarJugador(other));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (corrutinaAtaque != null)
        {
            StopCoroutine(corrutinaAtaque);
            corrutinaAtaque = null;
        }

        estaAtacando = false;
    }

    private IEnumerator AtacarJugador(Collider2D other)
    {
        estaAtacando = true;

        while (other != null && other.CompareTag("Player"))
        {
            vida v = other.GetComponent<vida>();
            if (v != null)
                v.TakeDamage();

            yield return new WaitForSeconds(tiempoEntreAtaques);
        }

        estaAtacando = false;
    }

    public void RecibirGolpe()
    {
        golpesRecibidos++;

        if (golpesRecibidos >= GOLPES_PARA_MORIR)
            Destroy(gameObject);
    }
}