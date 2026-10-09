using UnityEngine;

public class OyunIciButonSes : MonoBehaviour
{
    public void TiklamaSesi()
    {
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
        }
    }

    public void OyunaBasla()
    {
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
            OyunSesYoneticisi.Instance.OyunMuzigineGec();
        }
    }

    public void MenuyeDonus()
    {
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.ButonSesiCal();
            OyunSesYoneticisi.Instance.MenuMuzigineGec();
        }
    }
}
