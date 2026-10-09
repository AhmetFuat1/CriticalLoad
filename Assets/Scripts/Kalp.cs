using UnityEngine;

public class Kalp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.CompareTag("Platform") || temas.gameObject.CompareTag("Puan"))
        {
            CanSistemi canSistemi = FindAnyObjectByType<CanSistemi>();

            CisimEfekti objeCantasi = GetComponent<CisimEfekti>();

            if (objeCantasi != null && objeCantasi.yokOlmaEfekti != null)
            {
                Instantiate(objeCantasi.yokOlmaEfekti, transform.position, Quaternion.identity);
            }


            if (canSistemi != null)
            {
                canSistemi.CanArttir();
            }

            if (OyunSesYoneticisi.Instance != null)
            {
                OyunSesYoneticisi.Instance.KalpSesiCal();
            }

            Destroy(gameObject);
        }
        else if (temas.gameObject.CompareTag("Sinir"))
        {
            CisimEfekti objeCantasi = GetComponent<CisimEfekti>();

            if (objeCantasi != null && objeCantasi.yokOlmaEfekti != null)
            {
                Instantiate(objeCantasi.yokOlmaEfekti, transform.position, Quaternion.identity);
            }

            if (OyunSesYoneticisi.Instance != null)
            {
                OyunSesYoneticisi.Instance.YokOlmaSesiCal();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.CompareTag("Sinir"))
        {
            if (OyunSesYoneticisi.Instance != null)
            {
                OyunSesYoneticisi.Instance.YokOlmaSesiCal();
            }
            Destroy(gameObject);
        }
    }
}