using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RandomMessage : MonoBehaviour
{
    [Tooltip("Set the bound of a good day to get good messages.")]
    [SerializeField] int goodDay;

    [Tooltip("Set the bound of a mid day to get mid & bad (if below) messages.")]
    [SerializeField] int midDay;

    [SerializeField] GameObject sarcyText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;

    ScoreKeeper scoreKeeper;

    int day;

    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
        day = FindObjectOfType<ScoreKeeper>().GetWaveCount();



    }


    void Start()
    {


        SetUI();
    }

    void SetUI()
    {
        sarcyText.GetComponent<TextMeshProUGUI>().text = EvaluateScore(day);
        sarcyText.SetActive(true);


        scoreText.text = ("Score: ") + (scoreKeeper.GetScore());
        waveText.text = ("Day: ") + (scoreKeeper.GetWaveCount());
    }

    string EvaluateScore(int day)
    {
        string message;

        if (day > goodDay)
            message = RunGoodDay();
        else if (day > midDay)
            message = RunMidDay();
        else
            message = RunBadDay();

        return message;

    }


    string RunGoodDay()
    {
        string[] messages =
        {
            "The Kingdom celebrates with jubilation due to your productivity!",
            "A score so good, Juniper has risen from the dead to congratulate you!",
            "The oracles foretold of a day one such as you would come, the clearer of the Kingdom mines. Well done!",
            "Wow! Are there any gems left in those mines? You need a raise!",
            "Finally, a passable score. You're making the other miners look bad.",
            "You have tried very very hard, and today you have succeeded. You will look back on this day fondly."
        };

        int index = Random.Range(0, messages.Length);       

        return messages[index];

    }

    string RunBadDay()
    {
        string[] messages =
        {
            "An abysmal score, you'll be lucky if you have a job in the mines to come back to. Might be the thief life for the likes of you!",
            "Is the Kingdom a joke to you? This is an awful score. If we had 8,907 gophers like you the Kingdom would be in a dire state.",
            "You were either not trying, or you have absolutely no aptitude whatsoever for mining.",
            "A terrible, terrible score. Do better, or don't bother coming back.",
            "The Kingdom sheds a tear, Aldricus is crying. A truly awful score.",
            "They will look back on this day as the day a little gopher did absolutely nothing to help the Kingdom. Get a better score, or get out."
        };

        int index = Random.Range(0, messages.Length);       

        return messages[index];

    }

    string RunMidDay()
    {
        string[] messages =
        {
            "Not as bad a score as it could have been. But certainly not good. A lot of room for improvement.",
            "The wizards are laughing, becuase you tried to get a good score this time but still fell short.",
            "Clearly made a small effort, but still not good enough for this Kingdom. Come back when you're serious.",
            "You did at least slightly try this time. Well done.",
            "We've seen worse scores. Not many, but some.",
            "You need to take a long hard look at yourself, and tell us whether YOU think that was a good score. We know what we think..."
        };

        int index = Random.Range(0, messages.Length);       

        return messages[index];

    }





}
