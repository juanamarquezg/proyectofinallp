using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioescena : MonoBehaviour
{
    public int numeroEscena;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(numeroEscena);
        }
    }
}
