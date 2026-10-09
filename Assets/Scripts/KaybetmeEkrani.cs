using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class KaybetmeEkrani : MonoBehaviour
{
    
    public static KaybetmeEkrani instance;

    [Header("UI Elemanlarý")]
    public GameObject gameOverPanel; 
    public TextMeshProUGUI sureText;
    public GameObject oyunIciSayac;

    private float gecenSure = 0f;
    private bool oyunBittiMi = false;

    private void Awake()
    {
            instance = this;       
    }

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
        oyunBittiMi = false;
        gecenSure = 0f;
    }

    void Update()
    {

        if (!oyunBittiMi)
        {
            gecenSure += Time.deltaTime;
        }
    }

    public void OyunuBitir()
    {
        if (oyunBittiMi) return;

        oyunBittiMi = true;
        Time.timeScale = 0f; 

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);


        float dakika = Mathf.FloorToInt(gecenSure / 60);
        float saniye = Mathf.FloorToInt(gecenSure % 60);

        if (sureText != null)
            sureText.text = string.Format("{0:00}:{1:00}", dakika, saniye);

        if (oyunIciSayac != null)
        {
            oyunIciSayac.SetActive(false);
        }

        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.GameOverSesiCal();
        }

    }


    // --- BUTONLAR ÝÇÝN FONKSÝYONLAR ---

    public void TekrarOynaButonu()
    {
        Time.timeScale = 1f; 

        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuyeDonButonu()
    {
        Time.timeScale = 1f;

        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
            OyunSesYoneticisi.Instance.MenuMuzigineGec();
        }

        SceneManager.LoadScene("GirisMenusu");
    }

    public void CikisButonu()
    {
        Application.Quit();
    }
}