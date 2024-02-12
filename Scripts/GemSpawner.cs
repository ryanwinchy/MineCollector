using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    UIController uiController;

    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;

    ScoreKeeper scoreKeeper;

    AudioPlayer audioPlayer;

    [SerializeField] bool isLooping;   //So can make waves infinitely spawn.


    [Header("End Wave Settings")]
    [SerializeField] float timeAtEndOfDay;
    [SerializeField] float timeBeforeText;
    [SerializeField] float timeAtStartOfDay;
    [SerializeField] float fadeOutSpeed;
    [SerializeField] float timeBlackedOut;
    [SerializeField] float textDisplayDelay;
    Animator sunAnimator;

    public WaveConfigSO GetCurrentWave() => currentWave;        //Public getter to get current wave.



    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        sunAnimator = GameObject.Find("Sun").GetComponent<Animator>();
        uiController = FindObjectOfType<UIController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        StartCoroutine(SpawnGemWave());
        
    }


    IEnumerator SpawnGemWave()          //Cycle through 1 to 15, then randomly choose 5 to 15.
    {

            for (int i = 0; i < waveConfigs.Count; i++)  //Cycle thru waves. NEED TO ADD SO AFTER REACHES WAVE 10 OR SO START DOING RANDOM WAVES!
            {
                currentWave = waveConfigs[i];
                scoreKeeper.IncreaseWaveCount();
                

                for (int j = 0; j < currentWave.GetHowManyToSpawn(); j++)    //Cycle through spawnable objects.
                {
                    int index = Random.Range(0, currentWave.GetSpawnableObjectCount());        //Instantiate random gem prefab.
                    Instantiate(currentWave.GetSpawnableObject(index));
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());        //Delays (yields control) and then executes after specified time.
                }
                //ENDWAVE
                yield return new WaitForSeconds(timeBeforeText);
                uiController.TriggerEndOfWaveText(textDisplayDelay);
                audioPlayer.PlayNextDaySound();
                yield return new WaitForSeconds(timeAtEndOfDay);

                sunAnimator.SetBool("SunSet", true);
                uiController.ScreenInAndOut(fadeOutSpeed, timeBlackedOut);

                yield return new WaitForSeconds(timeAtStartOfDay);
            }

        while (isLooping)      //After run thru once, infinitely run randomly 6 to last.
        {
            int i = Random.Range(6, waveConfigs.Count);

            currentWave = waveConfigs[i];
            scoreKeeper.IncreaseWaveCount();

            for (int j = 0; j < currentWave.GetHowManyToSpawn(); j++)    //Cycle through spawnable objects.
            {
                int index = Random.Range(0, currentWave.GetSpawnableObjectCount());        //Instantiate random gem prefab.
                Instantiate(currentWave.GetSpawnableObject(index));
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());        //Delays (yields control) and then executes after specified time.
            }
            //ENDWAVE
            yield return new WaitForSeconds(timeBeforeText);
            uiController.TriggerEndOfWaveText(textDisplayDelay);
            audioPlayer.PlayNextDaySound();
            yield return new WaitForSeconds(timeAtEndOfDay);

            sunAnimator.SetBool("SunSet", true);
            uiController.ScreenInAndOut(fadeOutSpeed, timeBlackedOut);

            yield return new WaitForSeconds(timeAtStartOfDay);
        }

    }



 
    






}
