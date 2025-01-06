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
        score = 0;
        lives = 3;
        Time.timeScale = 1;
        isPlaying = true;
        StartCoroutine(spawnTarget());
    }
    void Update()
    {
        scoreTxt.text = "SCORE: " + score.ToString();
        livesTxt.text = "LIVES: " + lives.ToString();
        if (lives == 0)
        {
            isPlaying = false;
            gameOverTxt.text = "GAME OVER!";
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
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
