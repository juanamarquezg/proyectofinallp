using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    private const int Corazones_maximos = 3;
    private const int Cuartos_Por_corazon = 4;
    private const int MAX_HP = Corazones_maximos * Cuartos_Por_corazon;

    public int numeroEscena;
    public float Duracion_invulnerabilidad = 0.8f;

    private int _HP_actuales;
    private bool Es_invulnerable;
    private bool Esta_muerto;

    public int HP_actuales => _HP_actuales;
    public int Max_HP => MAX_HP;
    public bool Estavivo => !Esta_muerto;
    public float Porcentaje_salud => (float)_HP_actuales / MAX_HP;

    public System.Action<int, int> OnHealthChanged;
    public System.Action OnPlayerDied;

    private void Awake()
    {
        _HP_actuales = MAX_HP;
        Es_invulnerable = false;
        Esta_muerto = false;

        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        if (escenaActual == 0)
            enabled = false;
    }

    public void TakeDamage()
    {
        if (Esta_muerto || Es_invulnerable) return;

        _HP_actuales = Mathf.Max(0, _HP_actuales - 1);
        OnHealthChanged?.Invoke(_HP_actuales, MAX_HP);

        if (_HP_actuales <= 0)
            Die();
        else
            StartCoroutine(InvulnerabilityRoutine());
    }

    public void Heal(int amount = 1)
    {
        if (Esta_muerto) return;
        _HP_actuales = Mathf.Min(MAX_HP, _HP_actuales + amount);
        OnHealthChanged?.Invoke(_HP_actuales, MAX_HP);
    }

    public void FullHeal() => Heal(MAX_HP - _HP_actuales);

    private void Die()
    {
        if (Esta_muerto) return;
        Esta_muerto = true;
        OnPlayerDied?.Invoke();
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.2f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(numeroEscena);
    }

    private IEnumerator InvulnerabilityRoutine()
    {
        Es_invulnerable = true;
        float elapsed = 0f;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        while (elapsed < Duracion_invulnerabilidad)
        {
            if (sr != null) sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        if (sr != null) sr.enabled = true;
        Es_invulnerable = false;
    }
}