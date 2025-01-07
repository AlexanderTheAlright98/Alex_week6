using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public Transform targetParent;
    public TMP_Text scoreTxt, livesTxt, gameOverTxt;

    public int score, lives;
    public bool isPlaying;
    void Start()
    {
        scoreTxt.text = "SCORE: 0";
        livesTxt.text = "LIVES: 3";
        score = 0;
        lives = 3;
        Time.timeScale = 1;
        isPlaying = true;
        StartCoroutine(spawnTarget());
    }
    void Update()
    {
        if (!isPlaying)
        {
            gameOverTxt.text = "GAME OVER";
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }

    }
    public void updateLives(int livesChange)
    {
        lives += livesChange;
        livesTxt.text = "LIVES: " + lives;
        
        if (lives == 0)
        {
            isPlaying = false;
        }
    }
    public void updateScore(int scoreChange)
    {
        score += scoreChange;
        scoreTxt.text = "SCORE: " + score;

        if (score < 0)
        {
            score = 0;
            scoreTxt.text = "SCORE: 0";
        }
    }
    IEnumerator spawnTarget()
    {
        while (isPlaying)
        {
            float spawnRate = Random.Range(0.33f, 1.75f);

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], targetParent);
        }
    }
}
