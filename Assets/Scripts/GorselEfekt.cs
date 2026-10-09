using UnityEngine;
using TMPro;
using System.Collections;

public class GorselEfekt : MonoBehaviour
{
    public float animasyonSuresi = 1f;
    public Vector3 yukselmeMiktari = new Vector3(0, 50f, 0);
    public float sagaKaydirmaMiktari = 0f;
    private TextMeshProUGUI textBileseni;

    public void EfektiBaslat(string metin, Color renk)
    {
        textBileseni = GetComponent<TextMeshProUGUI>();
        textBileseni.text = metin;
        textBileseni.color = renk;

        transform.position += new Vector3(sagaKaydirmaMiktari, 0, 0);

        StartCoroutine(AnimasyonUygula());
    }

    private IEnumerator AnimasyonUygula()
    {
        Vector3 baslangicPoz = transform.position;
        Vector3 hedefPoz = baslangicPoz + yukselmeMiktari;
        float gecenSure = 0f;

        while (gecenSure < animasyonSuresi)
        {
            gecenSure += Time.deltaTime;
            float oran = gecenSure / animasyonSuresi;

  
            transform.position = Vector3.Lerp(baslangicPoz, hedefPoz, oran);

            float olcek = Mathf.Sin(oran * Mathf.PI);
            transform.localScale = new Vector3(olcek, olcek, olcek);

            yield return null;
        }

        Destroy(gameObject);
    }
}