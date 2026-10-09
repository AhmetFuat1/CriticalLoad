using UnityEngine;

public class YerKontrol : MonoBehaviour
{
    public CanSistemi canSistemi;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bomba"))
        {
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Cisim") || collision.gameObject.CompareTag("Puan"))
        {

            CisimEfekti objeCantasi = collision.gameObject.GetComponent<CisimEfekti>();

            if (objeCantasi != null && objeCantasi.yokOlmaEfekti != null)
            {
                Instantiate(objeCantasi.yokOlmaEfekti, collision.transform.position, Quaternion.identity);
            }

            SpriteRenderer gorsel = collision.gameObject.GetComponent<SpriteRenderer>();
            if (gorsel != null)
            {
                gorsel.enabled = false;
            }

            if (canSistemi != null)
            {
                canSistemi.CanAzalt();
            }

            if (OyunSesYoneticisi.Instance != null)
            {
                OyunSesYoneticisi.Instance.YokOlmaSesiCal();
            }

            Destroy(collision.gameObject);
        }
    }
}