using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{

    public GameObject kutuPrefab;
    public GameObject[] kutuSpawnerNoktalari;
    public float kutuMinAralik = 1.0f;
    public float kutuMaxAralik = 3.0f;
    public float kutuHizlanmaFaktoru = 90f;

    public GameObject buyukKutuPrefab; 
    public GameObject[] buyukKutuSpawnerNoktalari; 
    public float buyukKutuMinAralik = 1.5f; 
    public float buyukKutuMaxAralik = 4.0f; 
    public float buyukKutuHizlanmaFaktoru = 120f; 
    public float buyukKutuBaslangicSuresi = 45f; 
 
    public GameObject LkutuPrefab;
    public GameObject[] LkutuSpawnerNoktalari;
    public float LkutuMinAralik = 2.0f;
    public float LkutuMaxAralik = 5.0f;
    public float LkutuHizlanmaFaktoru = 150f;
    public float LkutuBaslangicSuresi = 90f;

    public GameObject BombaPrefab;
    public GameObject[] BombaSpawnerNoktalari;
    public float bombaMinAralik = 1.0f;
    public float bombaMaxAralik = 3.0f;
    public float bombaHizlanmaFaktoru = 90f;
    public float bombaBaslangicSuresi = 90f;

    public GameObject kalpPrefab;
    public GameObject[] kalpSpawnerNoktalari;
    public float kalpSpawnSuresi = 50f;

    private float oyunSuresi = 0f;
    public static bool birObjeSpawnlaniyorMu = false;

    private float guvenlikAraligi = 1.5f;

    private void Awake()
    {
        birObjeSpawnlaniyorMu = false;
    }

    void Start()
    {
        StartCoroutine(SpawnKutu());
        StartCoroutine(SpawnBuyukKutu());
        StartCoroutine(SpawnKapi());
        StartCoroutine(SpawnBomba());
        StartCoroutine(SpawnKalp());
    }

    void Update()
    {
        oyunSuresi += Time.deltaTime;
    }

    IEnumerator SpawnKutu()
    {
        while (true)
        {
            while (birObjeSpawnlaniyorMu) yield return null; 

            birObjeSpawnlaniyorMu = true;
            SpawnEt(kutuSpawnerNoktalari, kutuPrefab);

            yield return new WaitForSeconds(guvenlikAraligi);
            birObjeSpawnlaniyorMu = false;

            float aralik = HesaplaDinamikAralik(kutuMinAralik, kutuMaxAralik, kutuHizlanmaFaktoru);
            yield return new WaitForSeconds(aralik);
        }
    }

    IEnumerator SpawnBuyukKutu()
    {
        yield return new WaitForSeconds(buyukKutuBaslangicSuresi);

        while (true)
        {
            float aralik = HesaplaDinamikAralik(buyukKutuMinAralik, buyukKutuMaxAralik, buyukKutuHizlanmaFaktoru);
            yield return new WaitForSeconds(aralik);

            while (birObjeSpawnlaniyorMu) yield return null;

            birObjeSpawnlaniyorMu = true;
            SpawnEt(buyukKutuSpawnerNoktalari, buyukKutuPrefab);
            yield return new WaitForSeconds(guvenlikAraligi);
            birObjeSpawnlaniyorMu = false;
        }
    }

    IEnumerator SpawnKapi()
    {
        yield return new WaitForSeconds(LkutuBaslangicSuresi);

        while (true)
        {
            float aralik = HesaplaDinamikAralik(LkutuMinAralik, LkutuMaxAralik, LkutuHizlanmaFaktoru);
            yield return new WaitForSeconds(aralik);

            while (birObjeSpawnlaniyorMu) yield return null;
           
            birObjeSpawnlaniyorMu = true;
            SpawnEt(LkutuSpawnerNoktalari, LkutuPrefab);
            yield return new WaitForSeconds(guvenlikAraligi);
            birObjeSpawnlaniyorMu = false;
        }
    }

    IEnumerator SpawnBomba()
    {
        yield return new WaitForSeconds(bombaBaslangicSuresi);

        while (true)
        {
            float aralik = HesaplaDinamikAralik(bombaMinAralik, bombaMaxAralik, bombaHizlanmaFaktoru);
            yield return new WaitForSeconds(aralik);

            while (birObjeSpawnlaniyorMu) yield return null;

            birObjeSpawnlaniyorMu = true;
            SpawnEt(BombaSpawnerNoktalari, BombaPrefab);
            yield return new WaitForSeconds(guvenlikAraligi);
            birObjeSpawnlaniyorMu = false;
        }
    }

    IEnumerator SpawnKalp()
    {
        yield return new WaitForSeconds(kalpSpawnSuresi);

        while (true)
        {
            while (birObjeSpawnlaniyorMu)
            {
                yield return null;
            }

            birObjeSpawnlaniyorMu = true;

            SpawnEt(kalpSpawnerNoktalari, kalpPrefab);

            yield return new WaitForSeconds(guvenlikAraligi);
            birObjeSpawnlaniyorMu = false;
            yield return new WaitForSeconds(kalpSpawnSuresi);
        }
    }

    float HesaplaDinamikAralik(float min, float max, float hizlanmaFaktoru)
    {
        float t = oyunSuresi / hizlanmaFaktoru;
        float zorlukFaktoru = Mathf.Clamp01(t);
        return Mathf.Lerp(max, min, zorlukFaktoru);
    }

    void SpawnEt(GameObject[] spawnerNoktalari, GameObject prefab)
    {
        if (spawnerNoktalari.Length == 0 || prefab == null) return;

        int rastgeleIndex = Random.Range(0, spawnerNoktalari.Length);
        Transform spawnerPozisyonu = spawnerNoktalari[rastgeleIndex].transform;

        Instantiate(prefab, spawnerPozisyonu.position, Quaternion.identity);
    }
}