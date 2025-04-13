using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private AudioSource _audioSource;

    [SerializeField] private float speed = 1f;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private GameManager gameManager; // GameManager referansı

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        var random = Random.value > .5f ? 1 : -1;
        var force = new Vector2(random, -1);
        _rigidbody2D.AddForce(force.normalized * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Breakable"))
        {
            other.gameObject.SetActive(false); // Bloğu pasif hale getir
            levelManager.BlockBroken(); // Kırılan bloğu bildir
            ScoreManager.Instance.AddScore(5); // Her kırılan blok için 10 puan ekle

            PlaySound(breakSound);

            if (levelManager.CheckWin())
            {
                Debug.Log("You Win!");
                Time.timeScale = 0;
            }
        }
        else if (other.transform.CompareTag("GameOver"))
        {
            Debug.Log("Game Over");
            gameManager.GameOver(); // GameManager içindeki GameOver() fonksiyonunu çağır
        }
        else
        {
            PlaySound(bounceSound);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (_audioSource != null && clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
