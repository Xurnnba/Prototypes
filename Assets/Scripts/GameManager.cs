using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gM;

    public List<GameObject> targets;

    public float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool isgameActive;

    public Button restartButton;

    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        gM = this;
    }

    public void StartGame(int difficulty)
    {
        isgameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.SetActive(false);
        spawnRate /= difficulty;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isgameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text="Score: "+score;
    }

    IEnumerator SpawnTarget()
    {
        while (isgameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DetectScore()
    {
        if (score < 0)
        {
            GameOver();
        }

    }


    // Update is called once per frame
    void Update()
    {
        DetectScore();
    }
}
