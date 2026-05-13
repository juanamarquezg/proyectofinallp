using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ContadorRegresivo : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public float tiempoInicial = 10f;
    public int numeroEscena; 

    private float tiempoActual;
    private bool yaCambio = false; 

    void Start()
    {
        tiempoActual = tiempoInicial;
        ActualizarTexto();
    }

    void Update()
    {
        if (yaCambio) return;

        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;

            if (tiempoActual < 0)
                tiempoActual = 0;

            ActualizarTexto();
        }
        else
        {
            yaCambio = true;
            CambiarEscena();
        }
    }

    void ActualizarTexto()
    {
        textoTiempo.text = Mathf.Ceil(tiempoActual).ToString();
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(numeroEscena);
    }
}