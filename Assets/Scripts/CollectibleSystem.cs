/* using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
// private interface IGameScore = 0;

public class CollectibleSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the GameObject that has collided with our trigger is tagged with CleanUp...
        if (collision.gameObject.tag == "Collectible")
        {
            // Then we use this method to destroy it
            Destroy(collision.gameObject);
            score = score + 1;
        }
    }
}
*/