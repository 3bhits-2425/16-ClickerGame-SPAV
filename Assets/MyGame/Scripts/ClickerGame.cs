using UnityEngine;
using TMPro;

public class ClickerGame : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject applePrefab;
    public Transform[] spawnPoints; // manuelle Positionen

    private int score = 0;
    private float spawnInterval = 1f;
    private float timer = 0f;
    private int nextIndex = 0;

    void Start()
    {
        LoadScore();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnApple();
            timer = 0f;
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("SavedScore", 0);
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    private void SpawnApple()
    {
        if (spawnPoints.Length == 0) return;

        // Reihenfolge durchgehen oder zufällig auswählen
        Transform spawnPoint = spawnPoints[nextIndex];
        nextIndex = (nextIndex + 1) % spawnPoints.Length;

        GameObject apple = Instantiate(applePrefab, spawnPoint.position, Quaternion.identity);
        apple.GetComponent<Apple>().clickerGame = this;
    }
}
