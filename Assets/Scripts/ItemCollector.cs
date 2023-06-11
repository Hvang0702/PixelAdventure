using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0; //count how many apples we have collected

    [SerializeField] private Text applesText; //For the text

    [SerializeField] private AudioSource audioSource; //for collecting the apples
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) //if we collide with the object "Apple" tag
        {
            //When the player collects the apple the audio will play
            audioSource.Play();

            //remove item from the game if collision occurs
            Destroy(collision.gameObject);
            apples++; //Increase the number of apples collected
            applesText.text = "Apples: " + apples; //Using UnityEngine.UI we update the text
        }
    }

    

}
