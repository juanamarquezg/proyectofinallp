using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private bool yaGolpeo = false;

    private void OnEnable()
    {
        yaGolpeo = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo") && !yaGolpeo)
        {
            Enemigo enemigo = other.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                enemigo.RecibirGolpe();
                yaGolpeo = true; 
            }
        }
    }
}