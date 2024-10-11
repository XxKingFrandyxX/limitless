using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour
{
    
    public string LevelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelName);    
    }


    void Start()
    {
        SceneManager.LoadScene(LevelName);
    }

    void Update()
    {
        SceneManager.LoadScene(LevelName);
    }
}
