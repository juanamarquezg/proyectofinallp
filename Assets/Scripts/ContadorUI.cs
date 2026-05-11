using UnityEngine;
using TMPro;

public class ContadorUI : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    private Contador _contador;

    private void Start()
    {
        _contador = FindObjectOfType<Contador>();
    }

    private void Update()
    {
        if (_contador == null) return;

        float tiempo = _contador.TiempoRestante;
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        textoContador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}