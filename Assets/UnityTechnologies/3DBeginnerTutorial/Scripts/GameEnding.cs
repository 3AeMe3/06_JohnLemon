using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;

    bool isPlayerAtExit,isPlayerCought;

    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup coughtBackgroundImageCanvasGroup;

    float displayImageDuration;

    float timer;

    public AudioSource exitAudio,caughtAudio;
    bool hasAudioPlayed;
   

    private void Start()
    {
   

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    private void Update()
    {
        if (isPlayerAtExit)
        {
            
            EndLevel(exitBackgroundImageCanvasGroup,false,exitAudio);

        }
        else if (isPlayerCought)
        {
            
            EndLevel(coughtBackgroundImageCanvasGroup,true,caughtAudio);
        }
    }
    void EndLevel(CanvasGroup isCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }


        timer += Time.deltaTime;
        isCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void CathPlayer()
    {
        isPlayerCought = true;
    }
}
