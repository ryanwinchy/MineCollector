using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject blackSquare;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI livesText;

    [SerializeField] GameObject endOfWave;
    TextMeshProUGUI endOfWaveText;

    [SerializeField] GameObject instructions;


    ScoreKeeper scoreKeeper;


    // Start is called before the first frame update
    void Start()
    {
        endOfWaveText = endOfWave.GetComponent<TextMeshProUGUI>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        //endOfWaveText.text = ("End of day ") + (scoreKeeper.GetWaveCount());
        scoreText.text = ("Score: ") + (scoreKeeper.GetScore());
        waveText.text = ("Day: ") + (scoreKeeper.GetWaveCount());
        livesText.text = ("Lives: ") + (scoreKeeper.GetLives());
    }

    public void ScreenInAndOut(float speed, float delay) => StartCoroutine(FadeScreen(speed, delay));

    public void DisplayInitialInstructions()
    {
        if (instructions != null)
            instructions.SetActive(true);
    }
        
    public void ClearInstructions()
    {
        if (instructions != null)
            Destroy(instructions);
    }
        


    IEnumerator FadeScreen(float fadeSpeed = 20,  float blackDelay = 2)    //These are defaults, if no args given will default to this.
    {
        Color objectColour = blackSquare.GetComponent<Image>().color;    //may have to do image.
        float fadeAmount;


        while (blackSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime);     //Had / 20 to slow down.

            objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objectColour;

            yield return null;   //Executes over multiple frames.
        }

        yield return new WaitForSeconds(blackDelay);
        
        while (blackSquare.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime);

            objectColour = new Color(objectColour.r, objectColour.g, objectColour.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = objectColour;
            yield return null;
        }
        

    }

    public void TriggerEndOfWaveText(float delay) => StartCoroutine(DisplayEndOfWave(delay));

    IEnumerator DisplayEndOfWave(float delay)
    {
        endOfWaveText.text = ("End of day ") + (scoreKeeper.GetWaveCount());
        endOfWave.SetActive(true);
        yield return new WaitForSeconds(delay);
        endOfWave.SetActive(false);
    }


    public void ColourRedOrGreen(bool red) => StartCoroutine(ColourText(red));

    IEnumerator ColourText(bool red)
    {
        if (red)
            livesText.color = Color.red;
        else
            livesText.color = Color.green;

        yield return new WaitForSeconds(0.8f);

        livesText.color = Color.white;
    }
    




}
