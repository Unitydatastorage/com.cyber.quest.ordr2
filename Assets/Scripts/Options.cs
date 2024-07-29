using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    [SerializeField] Slider sounds;
    [SerializeField] Slider music;

    // Start is called before the first frame update
    void Start()
    {
        sounds.value = PlayerPrefs.GetFloat("sounds", 1);
        music.value = PlayerPrefs.GetFloat("music", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("last",2));
    }

    public void changeSounds()
    {
        PlayerPrefs.SetFloat("sounds", sounds.value);
        PlayerPrefs.Save();
        SoundManager.SoundVolume = sounds.value;
    }

    public void changeMusic()
    {
        PlayerPrefs.SetFloat("music", music.value);
        PlayerPrefs.Save();
        SoundManager.MusicVolume = music.value;
    }
}
