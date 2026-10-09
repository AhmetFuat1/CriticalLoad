using UnityEngine;
using TMPro; 

public class EnYuksekPuanKontrolu : MonoBehaviour
{
    [Header("UI Baðlantýsý")]
    public TMP_Text enYuksekPuanYazisi;

    private void OnEnable()
    {
        if (GameManager.Instance == null) return;

        int anlikPuan = GameManager.Instance.toplamPuan;

        int rekor = PlayerPrefs.GetInt("KaydedilenRekor", 0);

        if (anlikPuan > rekor)
        {
            rekor = anlikPuan; 

            PlayerPrefs.SetInt("KaydedilenRekor", rekor);
            PlayerPrefs.Save();
        }

        if (enYuksekPuanYazisi != null)
        {
            enYuksekPuanYazisi.text = "" + rekor.ToString();
        }
    }
}
