using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 1f;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
            scoreKeeper.ResetScores();


        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("OverScene", sceneLoadDelay));
    }


    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
