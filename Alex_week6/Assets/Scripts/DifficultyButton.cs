using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DifficultyButton : MonoBehaviour
{
    public GameManager gameManager;
    public float difficulty;

    Button diffButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diffButton = GetComponent<Button>();
        diffButton.onClick.AddListener(setDifficulty);
    }

    void setDifficulty()
    {
        gameManager.startGameState(difficulty);
    }
}
