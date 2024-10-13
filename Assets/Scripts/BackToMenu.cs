using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public string LevelName;

    private void OnTriggerEnter(){
        SceneManager.LoadScene(LevelName);
    }

    //Loads the scene of your choice

}
