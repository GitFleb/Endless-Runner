using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;
using TMPro;

public class CollectibleSystem : MonoBehaviour
{
    public GameObject player;
    public float gameScore = 0;
    public TMP_Text soulsText;
    Animator anim;



    public void Start()
    {
        // print("Working");
        anim.SetBool("gameScoreAni", false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If the GameObject that has collided with our trigger is tagged with Collectible...
        if (collision.gameObject.tag == "Collectible")
        {
            // Then we use this method to destroy it
            Destroy(collision.gameObject);
            gameScore += 1;  // And this to increase game score by 1
        }
    }

    public void Update()
    {
        // Update the score display and animation based on the current game score
        // print("test");
        soulsText.text = ("Souls: " + gameScore);
        // print("test2");
        if (gameScore >= 2)
        {
            anim.SetBool("gameScoreAni", true);
            print("Working");
        }
        else
        {
            anim.SetBool("gameScoreAni", false);
            print("Working2");
        }
        
        // soulsText.text = ("Souls: " + gameScore);
    }
}