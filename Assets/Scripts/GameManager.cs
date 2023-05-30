using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedDelta = 0.1f;

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
        NewGame();
    }
    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }

    private void Update()
    {
        gameSpeed += gameSpeedDelta * Time.deltaTime;
    }
}
