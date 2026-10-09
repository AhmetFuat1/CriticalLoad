using UnityEngine;
using System.Collections;

public class PuanOlusturma : MonoBehaviour
{
    private bool puanVerdiMi = false;

    public int kutuPuani = 10;

    private void OnCollisionEnter2D(Collision2D temasEdilenObje)
    {
        if (puanVerdiMi == true) 
            return;

        if (temasEdilenObje.gameObject.CompareTag("Platform") || temasEdilenObje.gameObject.CompareTag("Puan"))
        {
            PuanlamaIsleminiYap();
        }
    }

    private void PuanlamaIsleminiYap()
    {
        puanVerdiMi = true;

        gameObject.tag = "Puan";

        foreach (Transform altParca in transform)
        {
            altParca.gameObject.tag = "Puan";
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.PuanEkle(kutuPuani);
        }

        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.PuanSesiCal();
        }

        StartCoroutine(YesilYanipSonEfekti());
    }
    private IEnumerator YesilYanipSonEfekti()
    {
        SpriteRenderer[] tumGorseller = GetComponentsInChildren<SpriteRenderer>();

        Color[] orijinalRenkler = new Color[tumGorseller.Length];

        for (int i = 0; i < tumGorseller.Length; i++)
        {
            orijinalRenkler[i] = tumGorseller[i].color;
            tumGorseller[i].color = Color.green;
        }

        yield return new WaitForSeconds(0.15f);

        for (int i = 0; i < tumGorseller.Length; i++)
        {
            if (tumGorseller[i] != null)
            {
                tumGorseller[i].color = orijinalRenkler[i];
            }
        }
    }
}