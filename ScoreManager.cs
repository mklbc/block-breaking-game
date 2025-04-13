using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton tasarımı

    [SerializeField] private Text scoreText; // Puanı gösterecek UI Text
    private int score = 0; // Başlangıç puanı

    private void Awake()
    {
        // Singleton ayarı
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne değişse bile yok olmasın
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // Puanı artır
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // UI metnini güncelle
        }
    }
}
