using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

    public class CollectibleSystem : MonoBehaviour
    {
        public GameObject player;
        public int gameScore = 0;
        public TMP_Text soulsText;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            // If the GameObject that has collided with our trigger is tagged with Collectible...
            if (collision.gameObject.tag == "Collectible")
            {
                // Then we use this method to destroy it
                Destroy(collision.gameObject);
                gameScore = gameScore + 1;  // And this to increase game score by 1
            }
        }

        void Update()
        {
            soulsText.SetText("Souls: " + gameScore);
            if (gameScore >= 13)
            {
                Debug.Log("Transformation");
            }
        }
    }