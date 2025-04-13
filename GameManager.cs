using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Game Over Panel
    [SerializeField] private GameObject restartButton; // Restart Butonu

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Sahne yüklendiğinde tetiklenir
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Event kaldırılır
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sahne yüklendiğinde GameOverPanel ve RestartButton'ı yeniden bul
        gameOverPanel = GameObject.Find("GameOverPanel");
        restartButton = GameObject.Find("RestartButton");

        if (gameOverPanel == null || restartButton == null)
        {
            Debug.LogError("GameOverPanel veya RestartButton bulunamadı!");
        }
        else
        {
            gameOverPanel.SetActive(false); // Game Over Paneli kapalı başlat
            restartButton.SetActive(true); // Restart butonunu kapalı başlat
        }
    }

    public void GameOver()
    {
        if (gameOverPanel == null || restartButton == null)
        {
            Debug.LogError("GameOverPanel veya RestartButton eksik!");
            return;
        }

        gameOverPanel.SetActive(true); // Game Over Panelini aç
        restartButton.SetActive(true); // Restart butonunu aç
        Time.timeScale = 0; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Oyunu tekrar başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Sahneyi yeniden yükle

        // Sahne yeniden yüklendiğinde panel ve buton tekrar etkinleştirilecek
    }
}
