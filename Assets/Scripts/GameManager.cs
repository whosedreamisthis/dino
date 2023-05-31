using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedDelta = 0.1f;
    public float score;
    public float highScore;

    Player player;
    Spawner spawner;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        LoadHighScore();
        NewGame();

    }
    public void NewGame()
    {
        gameSpeed = initialGameSpeed;
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        spawner.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
        enabled = true;
        gameOverScreen.SetActive(false);
        score = 0;
        scoreText.text = "00000";
    }

    private void Update()
    {
        gameSpeed += gameSpeedDelta * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void GameOver()
    {
        gameSpeed = 0;
        enabled = false;
        spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
            PlayerPrefs.SetFloat("highScore", highScore);
        }
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetFloat("highScore", 0);
        highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }

}
