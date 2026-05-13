using UnityEngine;

public class movplayer : MonoBehaviour
{
    public float veloMove;
    public float x;
    public float y;

    public Animator animacaos;

   
    public GameObject hitbox;
    public float duracionHitbox = 0.2f;

    private bool golpeando = false;

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

        animacaos.SetBool("correvup", y > 0);
        animacaos.SetBool("correvdo", y < 0);

        
        if (Input.GetKeyDown(KeyCode.F) && !golpeando)
        {
            animacaos.SetTrigger("golpe");
            golpeando = true;

            ActivarHitbox();
            Invoke(nameof(DesactivarHitbox), duracionHitbox);
        }
    }

    void ActivarHitbox()
    {
        hitbox.SetActive(true);
    }

    void DesactivarHitbox()
    {
        hitbox.SetActive(false);
        golpeando = false;
    }
}