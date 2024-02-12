using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //REFACTORED - SINGLETON CAN ONLY REFERENCE SINGLETON OR WILL MESS UP. REMEMBER THIS, KEY LEARNING. AS OTHERWISE REFS DONT WORK PROPERLY BETWEEN SCENES. NULL CHECKS GOOD ALSO.

    int score;
    [SerializeField] int lives = 3;
    int waveCount = 0;

    static ScoreKeeper instance;  //Singleton. Only want one, persisting thru scenes.


    public int GetScore() => score;
    public int GetWaveCount() => waveCount;
    public int GetLives() => lives;

    public void ResetScores()
    {
        score = 0;
        lives = 3;
        waveCount = 0;
    }

    private void Awake()
    {
        ManageSingleton();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void IncreaseWaveCount() => waveCount++;

    public void UpdateLives(int damage) => lives -= damage;



        

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
    }

    public void AddScore(char ch)
    {
        switch(ch)
        {
            case 'E': score += 5; break;
            case 'G': score += 10; break;
            case 'Y': score += 1; break;
            default: break;
        }
    }
}
