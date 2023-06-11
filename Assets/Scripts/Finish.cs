using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;    


    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player collides with the flag 
        if (collision.gameObject.name == "Player" && !levelCompleted) 
        {
            finishSound.Play(); //play the finish audio
            levelCompleted = true; //the player won't be able to move once touching the flag
            Invoke("CompleteLevel", 2f); //when the player reaches the finish flag we wait 2 seconds until the next level
            
        }
    }

    private void CompleteLevel()
    {
        //+ 1 to add the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
