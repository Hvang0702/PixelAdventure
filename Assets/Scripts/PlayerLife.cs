using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim; //this variable will be used for the animation die 
    [SerializeField] private AudioSource death;

    private GameObject respawnPoint;
    private GameObject player;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //respawnPoint = GetComponent<GameObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) //we used the Trap tag for our spikes
        {
            death.Play();
            Die();
        }

    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; //when we hit the spike the player can not move anymore

        //switch to death animation when we collide with spikes
        anim.SetTrigger("death"); //Will execute the trigger "death" that we set 
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            //RestartLevel();
        }
    }
    */
    //reload the level after death
    
    private void RestartLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


}
