using UnityEngine;

public class PlatformController : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    public float speed = 5f;

    [Header("Hareket Sýnýrlarý")]
    public float minX;
    public float maxX;

    [Header("Pürüzsüz Kalkýþ (Kutularý Düþürmez)")]
    [Tooltip("Deðer büyüdükçe platform daha aðýr ve yumuþak hýzlanýr. (Örn: 0.3f ile 0.5f arasý)")]
    public float hareketYumusakligi = 0.3f;

    private float mevcutHizX;
    private float hizReferansi; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        float hedefHiz = horizontal * speed;
        mevcutHizX = Mathf.SmoothDamp(mevcutHizX, hedefHiz, ref hizReferansi, hareketYumusakligi);

        if ((rb.position.x <= minX && mevcutHizX < 0) || (rb.position.x >= maxX && mevcutHizX > 0))
        {
            mevcutHizX = 0f;
            hizReferansi = 0f; 
        }

        rb.linearVelocity = new Vector2(mevcutHizX, 0);

        Vector2 kilitliPozisyon = rb.position;
        kilitliPozisyon.x = Mathf.Clamp(kilitliPozisyon.x, minX, maxX);
        rb.position = kilitliPozisyon;
    }
}