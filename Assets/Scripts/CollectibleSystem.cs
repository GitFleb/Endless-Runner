using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;
using TMPro;

public class CollectibleSystem : MonoBehaviour
{
    public GameObject player;
    public float gameScore = 0;
    public TMP_Text soulsText;

    public void Start()
    {
        print("Working");
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
        soulsText.text = ("Souls: " + gameScore);
    }
}