using UnityEngine;
using UnityEngine.SceneManagement; 

public class AnaMenuYoneticisi : MonoBehaviour
{
    [Header("UI Panelleri")]
    public GameObject emegiGecenlerPanel;
    public GameObject AyarlarPanel;


    public void OyunaBasla()
    {
        SceneManager.LoadScene("Oyun");
    }

    
    public void EmegiGecenleriAc()
    {
        if (emegiGecenlerPanel != null)
        {
            emegiGecenlerPanel.SetActive(true); 
        }
    }

    public void AyarlariAc()
    {
        if (AyarlarPanel != null)
        {
            AyarlarPanel.SetActive(true);
        }
    }

    public void EmegiGecenleriKapat()
    {
        if (emegiGecenlerPanel != null)
        {
            emegiGecenlerPanel.SetActive(false); 
        }
    }

    public void AyarlariKapat()
    {
        if (AyarlarPanel != null)
        {
            AyarlarPanel.SetActive(false);
        }
    }


    public void OyundanCikis()
    {
        Application.Quit(); 
    }
}