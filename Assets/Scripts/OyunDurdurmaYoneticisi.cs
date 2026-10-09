using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OyunDurdurmaYoneticisi : MonoBehaviour, IPointerDownHandler
{
    [Header("UI Elemanlarý")]
    public GameObject pausePanel;
    public GameObject ayarlarPanel;

    private bool oyunDuraklatildi = false;

    void Start()
    {
        if (pausePanel != null) pausePanel.SetActive(false);
        if (ayarlarPanel != null) ayarlarPanel.SetActive(false);

        Time.timeScale = 1f;
        oyunDuraklatildi = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f && !oyunDuraklatildi) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ayarlarPanel != null && ayarlarPanel.activeSelf)
            {
                PauseDon();
            }
            else if (oyunDuraklatildi)
            {
                DevamEt();
            }
            else
            {
                Durdur();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
        }

        if (!oyunDuraklatildi)
        {

            Durdur();
        }

        else
        {
            DevamEt();
        }
    }

    public void Durdur()
    {
        oyunDuraklatildi = true;

        if (pausePanel != null) pausePanel.SetActive(true);
        if (ayarlarPanel != null) ayarlarPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void DevamEt()
    {
        oyunDuraklatildi = false;

        if (pausePanel != null) pausePanel.SetActive(false);
        if (ayarlarPanel != null) ayarlarPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void AyarlarAc()
    {
        if (ayarlarPanel != null)
        {
            ayarlarPanel.SetActive(true);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    public void PauseDon()
    {
        if (ayarlarPanel != null)
        {
            ayarlarPanel.SetActive(false);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void MenuyeDonButonu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("GirisMenusu");
    }

    public void OyundanCikis()
    {
        Debug.Log("Oyundan Çýkýlýyor...");
        Application.Quit();
    }
}