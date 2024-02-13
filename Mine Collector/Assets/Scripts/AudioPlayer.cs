using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    static AudioPlayer instance;

    [SerializeField] AudioClip emptySpellClip;
    [SerializeField] [Range(0f,1f)] float emptySpellVolume = 1f;

    [SerializeField] AudioClip holyClip;
    [SerializeField][Range(0f, 1f)] float holyVolume = 1f;

    [SerializeField] AudioClip gemHitCartClip;
    [SerializeField][Range(0f, 1f)] float gemHitCartVolume = 1f;

    [SerializeField] AudioClip oneUpClip;
    [SerializeField][Range(0f, 1f)] float oneUpVolume = 1f;

    [SerializeField] AudioClip obstacleHitCartClip;
    [SerializeField][Range(0f, 1f)] float obstacleHitCartVolume = 1f;

    [SerializeField] AudioClip gemCrackClip;
    [SerializeField][Range(0f, 1f)] float gemCrackVolume = 1f;

    [SerializeField] AudioClip obstacleHitGroundClip;
    [SerializeField][Range(0f, 1f)] float obstacleHitGroundVolume = 1f;

    [SerializeField] AudioClip lightObstacleHitGroundClip;
    [SerializeField][Range(0f, 1f)] float lightObstacleHitGroundVolume = 1f;

    [SerializeField] AudioClip nextDay;
    [SerializeField][Range(0f, 1f)] float nextDayVolume = 1f;

    [SerializeField] AudioClip deathSound;
    [SerializeField][Range(0f, 1f)] float deathVolume = 1f;

    private void Awake()
    {
        ManageSingleton();
    }

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


    public void PlayEmptySound() => PlayClip(emptySpellClip, emptySpellVolume);

    public void PlayHolySound() => PlayClip(holyClip, holyVolume);

    public void PlayGemHitCart() => PlayClip(gemHitCartClip, gemHitCartVolume);

    public void PlayOneUp() => PlayClip(oneUpClip, oneUpVolume);

    public void PlayObstacleHitCart() => PlayClip(obstacleHitCartClip, obstacleHitCartVolume);

    public void PlayGemCrack() => PlayClip(gemCrackClip, gemCrackVolume);

    public void PlayObstacleHitGround() => PlayClip(obstacleHitGroundClip, obstacleHitGroundVolume);

    public void PlayLightObstacleHitGround() => PlayClip(lightObstacleHitGroundClip, lightObstacleHitGroundVolume);
    public void PlayNextDaySound() => PlayClip(nextDay, nextDayVolume);
    public void PlayDeathSound() => PlayClip(deathSound, deathVolume);



    void PlayClip(AudioClip clip, float volume)         //Generic method so don't have to copy and paste this when playing all clips.
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }

   



}
