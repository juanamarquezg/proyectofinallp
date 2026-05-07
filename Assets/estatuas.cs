using TMPro;
using UnityEngine;

public class estatuas : MonoBehaviour
{
    private int puntuacion;
    public TextMeshProUGUI puntuacionTexto;
    public GameObject Puerta;
    public GameObject panelAdivinanza; 

    void OnMouseDown()
    {
        puntuacion = int.Parse(puntuacionTexto.text);
        puntuacion++;
        puntuacionTexto.text = puntuacion.ToString();

        panelAdivinanza.SetActive(true);

        if (puntuacion >= 2)
        {
            Puerta.SetActive(true);
        }

        Destroy(gameObject);
    }
}
