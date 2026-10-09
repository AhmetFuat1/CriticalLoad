using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OyunSesYoneticisi : MonoBehaviour
{
    public static OyunSesYoneticisi Instance;

    [Header("Müzik Dosyalarý")]
    public AudioClip menuMuzigi;     
    public AudioClip oyunIciMuzik;   

    [Header("Ses Efektleri")]
    public AudioClip yokOlmaSesi;
    public AudioClip gameOverSesi;
    public AudioClip butonSesi;
    public AudioClip puanSesi;
    public AudioClip kalpSesi;

    [Header("Ses Seviyeleri (Mikser)")]
    [Range(0f, 1f)] public float muzikSesSeviyesi = 0.4f;
    [Range(0f, 1f)] public float efektGenelSesSeviyesi = 1.0f;

    [Range(0f, 1f)] public float yokOlmaSesDengesi = 1.0f;
    [Range(0f, 1f)] public float gameOverSesDengesi = 0.8f;
    [Range(0f, 1f)] public float butonSesDengesi = 0.8f;
    [Range(0f, 1f)] public float puanSesDengesi = 1.0f;
    [Range(0f, 1f)] public float kalpSesDengesi = 1.0f;


    private AudioSource muzikKaynagi;
    private AudioSource efektKaynagi;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        muzikKaynagi = GetComponent<AudioSource>();
        efektKaynagi = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {

        MuzikCal(menuMuzigi);
    }

    void Update()
    {
        if (muzikKaynagi != null)
        {
            muzikKaynagi.volume = muzikSesSeviyesi;
        }
    }

    public void MuzikCal(AudioClip muzik)
    {
        if (muzik != null && (muzikKaynagi.clip != muzik || !muzikKaynagi.isPlaying))
        {
            muzikKaynagi.clip = muzik;
            muzikKaynagi.loop = true;
            muzikKaynagi.volume = muzikSesSeviyesi;
            muzikKaynagi.Play();
        }
    }

    public void OyunMuzigineGec()
    {
        MuzikCal(oyunIciMuzik);
    }

    public void MenuMuzigineGec()
    {
        MuzikCal(menuMuzigi);
    }

    public void MuzigiDurdur()
    {
        muzikKaynagi.Stop();
    }

    public void GenelSesiAyarla(float deger)
    {
        AudioListener.volume = deger;
    }

    public void MuzikSesiAyarla(float deger)
    {
        muzikSesSeviyesi = deger;

        if (muzikKaynagi != null) muzikKaynagi.volume = muzikSesSeviyesi;
    }

    public void EfektSesiAyarla(float deger)
    {
        efektGenelSesSeviyesi = deger;
    }

    public void YokOlmaSesiCal()
    {
        if (yokOlmaSesi != null)
        {
            efektKaynagi.pitch = Random.Range(0.9f, 1.1f);
            efektKaynagi.PlayOneShot(yokOlmaSesi, yokOlmaSesDengesi * efektGenelSesSeviyesi);
        }
    }

    public void GameOverSesiCal()
    {
        if (gameOverSesi != null)
        {
            MuzigiDurdur();
            efektKaynagi.pitch = 1.0f;
            efektKaynagi.PlayOneShot(gameOverSesi, gameOverSesDengesi * efektGenelSesSeviyesi);
        }
    }

    public void ButonSesiCal()
    {
        if (butonSesi != null)
        {
            efektKaynagi.pitch = 1.0f;
            efektKaynagi.PlayOneShot(butonSesi, butonSesDengesi * efektGenelSesSeviyesi);
        }
    }

    public void PuanSesiCal()
    {
        if (puanSesi != null)
        {
            efektKaynagi.pitch = Random.Range(0.95f, 1.05f);
            efektKaynagi.PlayOneShot(puanSesi, puanSesDengesi * efektGenelSesSeviyesi);
        }
    }

    public void KalpSesiCal()
    {
        if (kalpSesi != null)
        {
            efektKaynagi.pitch = Random.Range(0.95f, 1.05f);
            efektKaynagi.PlayOneShot(kalpSesi, kalpSesDengesi * efektGenelSesSeviyesi);
        }
    }
}