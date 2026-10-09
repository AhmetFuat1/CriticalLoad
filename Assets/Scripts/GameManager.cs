using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Arayüz Ayarlarý")]

    public TextMeshProUGUI puanYazisi;
    public TextMeshProUGUI puanYazisi2;

    [Header("Efekt Ayarlarý")]
    public GameObject kayanYaziPrefab;
    public Transform puanSayaciTransform;

    public int toplamPuan = 0; 

    private void Awake()
    {
  
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        EkranaPuaniYaz();
        if (OyunSesYoneticisi.Instance != null)
        {
            OyunSesYoneticisi.Instance.OyunMuzigineGec();
        }
    }


    public void PuanEkle(int eklenecekPuan)
    {
        toplamPuan += eklenecekPuan; 
        EkranaPuaniYaz();
        if (kayanYaziPrefab != null && puanSayaciTransform != null)
        {
            GameObject yeniYazi = Instantiate(kayanYaziPrefab, puanSayaciTransform.position, Quaternion.identity, puanSayaciTransform.parent);

            yeniYazi.GetComponent<GorselEfekt>().EfektiBaslat("+" + eklenecekPuan.ToString(), Color.yellow);
        }
    }

    private void EkranaPuaniYaz()
    {
        if (puanYazisi != null)
        {
            puanYazisi.text = "" + toplamPuan.ToString();
            puanYazisi2.text = "" + toplamPuan.ToString();
        }
    }
}