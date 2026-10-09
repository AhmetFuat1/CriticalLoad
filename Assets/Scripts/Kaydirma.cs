using UnityEngine;

public class Kaydirma : MonoBehaviour
{
    [Header("Ayarlar")]
    public float BitisYPozisyonu = -30f; 
    public float KaydirmaHizi = 1f; 

    private Vector3 baslangicPozisyonu;

    void Start()
    {
        
        baslangicPozisyonu = transform.position;
      
    }

    void Update()
    {
        transform.Translate(Vector3.down * KaydirmaHizi * Time.deltaTime);

        if (transform.position.y <= BitisYPozisyonu)
        {
  
            transform.position = new Vector3(transform.position.x, BitisYPozisyonu, transform.position.z);
   
            enabled = false;
        }
    }
}
