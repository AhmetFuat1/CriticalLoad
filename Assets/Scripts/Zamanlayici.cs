using UnityEngine;
using TMPro;

public class Zamanlayici : MonoBehaviour
{
    public TextMeshProUGUI zamanText;
    private float baslangicZamani;
    private bool oynuyormu = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (oynuyormu)
        {  
            float elapsedTime = Time.time - baslangicZamani;

            string dakika = ((int)elapsedTime / 60).ToString("00");
            string saniye = (elapsedTime % 60).ToString("00");

            zamanText.text = dakika + ":" + saniye;
        }
    }

    public void StartTimer()
    {
        
        baslangicZamani = Time.time;
        oynuyormu = true;
        zamanText.text = "00:00.00"; 
    }

    public float StopTimer()
    {
        oynuyormu = false;
        return Time.time - baslangicZamani;
    }
}
