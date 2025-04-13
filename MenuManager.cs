using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel; // Menü paneli referansı

    private void Start()
    {
        // Oyunu durdur ve menü panelini aç
        Time.timeScale = 0f; // Oyunu durdur
        menuPanel.SetActive(true); // Menü panelini aktif yap
    }

    public void StartGame()
    {
        // Menü panelini kapat ve oyunu başlat
        menuPanel.SetActive(false); // Menü panelini kapat
        Time.timeScale = 1f; // Oyunu başlat
    }

     public void ExitGame()
    {
        Debug.Log("Oyundan çıkıldı.");

        // Editör ortamında çıkışı simüle etmek için
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Gerçek build ortamında oyunu kapat
        Application.Quit();
#endif
    }
}
