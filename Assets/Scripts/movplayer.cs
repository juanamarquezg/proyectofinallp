using UnityEngine;


public class movplayer : MonoBehaviour
{
    public float veloMove;
    public float x;
    public float fuerzaDeSalto;
    public float y;

    public Animator animacaos;

    private bool golpeando = false;
    private float tiempoGolpe = 0f;
    public float duracionGolpe = 0.25f; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void Update()
    {
     
        x = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * x * veloMove * Time.deltaTime);

        if (x == 0)
            animacaos.SetBool("correh", false);
        else
        {
            animacaos.SetBool("correh", true);

            if (x < 0)
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            else if (x > 0)
                transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }

     
        y = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * y * veloMove * Time.deltaTime);

        animacaos.SetBool("correvup", false);
        animacaos.SetBool("correvdo", false);

        if (y > 0)
            animacaos.SetBool("correvup", true);
        else if (y < 0)
            animacaos.SetBool("correvdo", true);

        
        if (Input.GetKeyDown(KeyCode.F) && !golpeando)
        {
            animacaos.SetTrigger("golpe");
            golpeando = true;
            tiempoGolpe = duracionGolpe;
        }

        if (golpeando)
        {
            tiempoGolpe -= Time.deltaTime;

            if (tiempoGolpe <= 0)
            {
                golpeando = false;
            }
        }
    }

    private void OnTriggerstay2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo") && golpeando)
        {
            Destroy(other.gameObject);
        }
    }
}
