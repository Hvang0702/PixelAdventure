using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    //has to be public so we can call button
    public void Quit()
    {
        Application.Quit(); //quits application
    }
}
