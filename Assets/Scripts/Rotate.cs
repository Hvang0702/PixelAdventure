using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] private float speed = 2f; //rotate the saw 360 degrees two times = 720
    
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        //0, 0 for x and y rotation
        //use time.deltaTime 360 and speed
    }
}
