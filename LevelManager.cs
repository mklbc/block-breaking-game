using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject winText;

    [SerializeField] private GameObject breakablePrefab;
    [SerializeField] private Vector2Int size;
    [SerializeField] private Vector2 offset;

    private List<GameObject> breakables = new List<GameObject>(); // Kırılabilir nesnelerin listesi
    private int totalBreakableBlocks; // Toplam kırılabilir blok sayısı

    private void Start()
    {
        // Başlangıçta toplam kırılabilir blok sayısını ayarla
        totalBreakableBlocks = size.x * size.y;
    }

    public bool CheckWin()
    {
        
        // Eğer toplam kırılabilir blok sayısı 0 ise kazanıldı
        return totalBreakableBlocks <= 0; 
    }

    public void BlockBroken()
    {
        totalBreakableBlocks--; // Kırılan blok sayısını azalt
        if (CheckWin()) // Eğer tüm bloklar kırıldıysa
    {
        winText.SetActive(true); // Tebrik mesajını göster
        Debug.Log("You Win!"); // Konsola kazanma mesajı yazdır
        Time.timeScale = 0; // Oyunu durdur
    }
    }

    [ContextMenu(nameof(Create))]
    public void Create()
    {
        var parent = new GameObject { name = "BreakableBlocks" }; // Daha açıklayıcı isim

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var x = i * offset.x;
                var y = j * offset.y;
                var position = new Vector3(x, y, 0);
                var breakable = Instantiate(breakablePrefab, position, Quaternion.identity);
                breakable.transform.SetParent(parent.transform); // Nesneyi ebeveynine ata
                breakables.Add(breakable); // Listeye ekle
            }
        }

        // Ebeveynin ortasını hesapla
        Vector3 origin = Vector3.zero;
        foreach (var item in breakables)
        {
            origin += item.transform.position; // Ortaya ekle
        }
        origin /= breakables.Count; // Ortayı hesapla

        parent.transform.position = origin; // Ebeveynin konumunu ortala
    }
}
