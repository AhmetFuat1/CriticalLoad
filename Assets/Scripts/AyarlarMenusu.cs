using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AyarlarMenusu : MonoBehaviour
{
    [Header("Slider'larý Buraya Sürükle")]
    public Slider genelSesSlider;
    public Slider muzikSlider;
    public Slider efektSlider;

    [Header("Sayý Deðerlerini Gösteren Textler (TMP)")]
    public TMP_Text genelSesText;
    public TMP_Text muzikText;
    public TMP_Text efektText;

    void OnEnable()
    {

        if (genelSesSlider != null)
        {

            genelSesSlider.onValueChanged.RemoveAllListeners();

            genelSesSlider.value = AudioListener.volume;
            genelSesSlider.onValueChanged.AddListener(GenelSesAyarla);
            DegeriYaz(genelSesText, genelSesSlider.value);
        }

        if (muzikSlider != null && OyunSesYoneticisi.Instance != null)
        {
            muzikSlider.onValueChanged.RemoveAllListeners();

            muzikSlider.value = OyunSesYoneticisi.Instance.muzikSesSeviyesi;
            muzikSlider.onValueChanged.AddListener(MuzikAyarla);
            DegeriYaz(muzikText, muzikSlider.value);
        }

        if (efektSlider != null && OyunSesYoneticisi.Instance != null)
        {
            efektSlider.onValueChanged.RemoveAllListeners();

            efektSlider.value = OyunSesYoneticisi.Instance.efektGenelSesSeviyesi;
            efektSlider.onValueChanged.AddListener(EfektAyarla);
            DegeriYaz(efektText, efektSlider.value);
        }
    }

    public void GenelSesAyarla(float deger)
    {
        if (OyunSesYoneticisi.Instance != null)
            OyunSesYoneticisi.Instance.GenelSesiAyarla(deger);

        DegeriYaz(genelSesText, deger);
    }

    public void MuzikAyarla(float deger)
    {
        if (OyunSesYoneticisi.Instance != null)
            OyunSesYoneticisi.Instance.MuzikSesiAyarla(deger);

        DegeriYaz(muzikText, deger);
    }

    public void EfektAyarla(float deger)
    {
        if (OyunSesYoneticisi.Instance != null)
            OyunSesYoneticisi.Instance.EfektSesiAyarla(deger);

        DegeriYaz(efektText, deger);
    }

    private void DegeriYaz(TMP_Text textKutusu, float deger)
    {
        if (textKutusu != null)
        {

            int yuzde = Mathf.RoundToInt(deger * 100);
            textKutusu.text = yuzde.ToString();
        }
    }
}