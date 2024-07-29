using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void back()
    {
        SceneManager.LoadScene(2);
    }

    public void easy()
    {
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }

    public void middle()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }

    public void hard()
    {
        PlayerPrefs.SetInt("level", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(6);
    }

    public void goSettings()
    {
        PlayerPrefs.SetInt("last", 5);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }
}
