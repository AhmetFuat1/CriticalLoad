using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour
{
    [Header("Patlama Ayarlarý")]
    public float patlamaYaricapi = 4.0f;
    public float patlamaGecikmesi = 1.0f;
    public GameObject patlamaEfekti;

    private bool patladiMi = false;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {

        if (temas.gameObject.CompareTag("Sinir"))
        {
            Destroy(gameObject);
            return;
        }

        if (!patladiMi && (temas.gameObject.CompareTag("Platform") || temas.gameObject.CompareTag("Puan")))
        {
            StartCoroutine(PatlamaGeriSayim());
        }
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.CompareTag("Sinir"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PatlamaGeriSayim()
    {
        patladiMi = true;
        float sayac = 0;

        while (sayac < patlamaGecikmesi)
        {
            if (sr != null) sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            if (sr != null) sr.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            sayac += 0.2f;
        }

        GercekPatlama();
    }

    void GercekPatlama()
    {
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.YokOlmaSesiCal();
        }

        Collider2D[] etkilenenler = Physics2D.OverlapCircleAll(transform.position, patlamaYaricapi);
        foreach (Collider2D yakinObje in etkilenenler)
        {
            if (yakinObje.CompareTag("Puan"))
            {
                Destroy(yakinObje.gameObject);
            }
        }

        if (patlamaEfekti != null)
        {
            Vector3 poz = transform.position;
            poz.z = 0;

            GameObject efekt = Instantiate(patlamaEfekti, poz, Quaternion.identity);

            ParticleSystem ps = efekt.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
        }
        else
        {
            Debug.Log("Efekt atanmadý!");
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patlamaYaricapi);
    }
}