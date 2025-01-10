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
    public TMP_Text scoreTxt, livesTxt, gameOverTxt, finalScoreTxt, highScoreTxt;
    public GameObject gameOverScreen, inGameUI, newHighScore;

    public AudioSource musicSource;
    public AudioClip menuMusic, mainMusic, goodSFX, badSFX;

    public int score, lives;
    public bool isPlaying;
    public float spawnRate1, spawnRate2;
    void Start()
    {
        Time.timeScale = 1;
        musicSource.clip = menuMusic;
        musicSource.Play();
    }
    public void startGameState(float difficulty)
    {
        musicSource.Stop();
        musicSource.clip = mainMusic;
        musicSource.Play();
        spawnRate1 /= difficulty + 0.2f;
        spawnRate2 /= difficulty;
        scoreTxt.text = "SCORE: 0";
        livesTxt.text = "LIVES: 3";
        score = 0;
        lives = 3;
        isPlaying = true;
        StartCoroutine(spawnTarget());
    }
    public void goodSound()
    {
        musicSource.PlayOneShot(goodSFX);
    }
    public void badSound()
    {
        musicSource.PlayOneShot(badSFX);
    }
    void gameOverState()
    {
        isPlaying = false;
        Time.timeScale = (0);
        gameOverTxt.text = "GAME OVER";
        finalScoreTxt.text = "FINAL SCORE: " + score;
        highScoreTxt.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
        inGameUI.SetActive(false);
        gameOverScreen.SetActive(true);

        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            highScoreTxt.text = "OLD HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
            PlayerPrefs.SetInt("Highscore", score);
            newHighScore.SetActive(true);
            finalScoreTxt.text = "NEW HIGHSCORE: " + score;
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void updateLives(int livesChange)
    {
        lives += livesChange;
        livesTxt.text = "LIVES: " + lives;
        
        if (lives == 0)
        {
            gameOverState();
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
            float spawnRate = Random.Range(spawnRate1, spawnRate2);

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index], targetParent);
        }
    }
}
