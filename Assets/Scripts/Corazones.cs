using UnityEngine;
using UnityEngine.UI;

public class CorazonesUI : MonoBehaviour
{
    public Image[] corazones = new Image[3];
    public Sprite[] sprites_corazon = new Sprite[5];
    // sprites_corazon[0] = lleno
    // sprites_corazon[1] = 3/4
    // sprites_corazon[2] = 1/2
    // sprites_corazon[3] = 1/4
    // sprites_corazon[4] = vacío

    private vida _vida;

    private void Start()
    {
        _vida = GameObject.FindWithTag("Player").GetComponent<vida>();
        _vida.OnHealthChanged += ActualizarCorazones;
    }

    private void ActualizarCorazones(int HP_actuales, int Max_HP)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            int cuartos = Mathf.Clamp(HP_actuales - i * 4, 0, 4);
            corazones[i].sprite = sprites_corazon[4 - cuartos];
        }
    }

    private void OnDestroy()
    {
        if (_vida != null)
            _vida.OnHealthChanged -= ActualizarCorazones;
    }
}