using UnityEngine;

public class KutuFizik : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D altObjeninRb;
    bool zeminde;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionStay2D(Collision2D temas)
    {

        if (temas.contacts[0].normal.y > 0.5f)
        {
            altObjeninRb = temas.collider.GetComponent<Rigidbody2D>();
            zeminde = true;
        }
    }

    void OnCollisionExit2D(Collision2D temas)
    {
        zeminde = false;
        altObjeninRb = null;
    }

    void FixedUpdate()
    {

        if (zeminde && altObjeninRb != null)
        {
            rb.linearVelocity = new Vector2(altObjeninRb.linearVelocity.x, rb.linearVelocity.y);
        }
    }
}