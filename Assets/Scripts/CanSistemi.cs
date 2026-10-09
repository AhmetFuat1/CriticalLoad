using UnityEngine;
using TMPro;

public class CanSistemi : MonoBehaviour
{
    public int baslangicCani = 5;

    public TextMeshProUGUI canText;

    public GameObject kayanYaziPrefab;
    public Transform canSayaciTransform;

    private int mevcutCan;

    void Start()
    {
        mevcutCan = baslangicCani;
        CanGuncelle();
    }

    public void CanAzalt()
    {
        if (mevcutCan > 0)
        {
            mevcutCan--;
            CanGuncelle();


            if (mevcutCan <= 0)
            {
                mevcutCan = 0;
                if (KaybetmeEkrani.instance != null)
                {
                    KaybetmeEkrani.instance.OyunuBitir();
                }
            }
        }
    }

    public void CanArttir()
    {
            mevcutCan++;
            CanGuncelle();

        if (kayanYaziPrefab != null && canSayaciTransform != null)
        {
            GameObject yeniYazi = Instantiate(kayanYaziPrefab, canSayaciTransform.position, Quaternion.identity, canSayaciTransform.parent);
            yeniYazi.GetComponent<GorselEfekt>().EfektiBaslat("+1", Color.red);

        }
    }

    void CanGuncelle()
    {       
        if (canText != null)
        {
            canText.text = mevcutCan.ToString();
        }
    }

}