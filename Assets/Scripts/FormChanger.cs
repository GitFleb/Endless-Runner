using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class FormChanger : MonoBehaviour
{
    Animator anim;
    CollectibleSystem CS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CS = GetComponent<CollectibleSystem>();
        anim = GetComponent<Animator>();
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
    }
}
