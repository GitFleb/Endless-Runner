using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class FormChanger : MonoBehaviour
{
    Animator anim;
    public AudioClip gameClip;
    CollectibleSystem CS;
    AudioSource audioSource; // <- add this

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CS = GetComponent<CollectibleSystem>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // <- get the AudioSource component
    }
    public void Update()
    {
        // Update the score display and animation based on the current game score
        if (CS.gameScore >= 13)
        {
            anim.SetBool("gameScoreAni", true);
        }
        else if (CS.gameScore < 13)
        {
            anim.SetBool("gameScoreAni", false);
        }
        if (CS.gameScore == 12)
        {
            playMusic();
        }
    }

    void playMusic()
    {
        if (audioSource == null || gameClip == null) return;
        audioSource.clip = gameClip;
        audioSource.loop = false;
        audioSource.Play();
    }
}
