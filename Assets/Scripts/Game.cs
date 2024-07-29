using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRuby.SoundManagerNamespace;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField] GameObject[] frames;
    Item pressed;
    Item entered;
    [SerializeField] Item[] easy;
    [SerializeField] Item[] middle;
    [SerializeField] Item[] hard;
    [SerializeField] Sprite[] sprites;
    List<int> list;
    bool started = false, end = false;
    private int level;
    [SerializeField] Sprite ready;
    [SerializeField] Button button;
    [SerializeField] Text label;
    List<int> shuffled;

    [SerializeField] GameObject endframe;
    [SerializeField] Text endlabel;
    [SerializeField] Sprite next;
    [SerializeField] Sprite again;
    [SerializeField] GameObject stars;
    [SerializeField] Text endscore;

    [SerializeField] AudioSource winS;
    [SerializeField] AudioSource loseS;
 
    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < frames.Length; i++) frames[i].SetActive(false);
        level = PlayerPrefs.GetInt("level", 0);
        frames[level].SetActive(true);
        list = new List<int>();
        List<int> spritesInd = new List<int>();
        for (int i = 0; i < sprites.Length; i++) spritesInd.Add(i);
        spritesInd.Shuffle();
        if(level==0)
        {
            for (int i = 0; i < 3; i++) list.Add(spritesInd[i]);
            for(int i = 0;i<easy.Length;i++)
            {
                easy[i].image.sprite   = sprites[list[i]];
                easy[i].ind = list[i];
            }
        } else if(level==1)
        {
            for (int i = 0; i < 6; i++) list.Add(spritesInd[i]);
            for (int i = 0; i < middle.Length; i++)
            {
                middle[i].image.sprite = sprites[list[i]];
                middle[i].ind = list[i];
            }
        } else
        {
            for (int i = 0; i < 9; i++) list.Add(spritesInd[i]);
            for (int i = 0; i < hard.Length; i++)
            {
                hard[i].image.sprite = sprites[list[i]];
                hard[i].ind = list[i];
            }
        }
        string s = "";
        for (int i = 0; i < list.Count; i++) s += list[i] + " ";
        print(s);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        SceneManager.LoadScene(2);
    }

    public void settings()
    {
        PlayerPrefs.SetInt("last", 6);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    public void up()
    {
        if(started)
        {
            if (pressed != null && entered != null)
            {
              //  Vector2 pos = pressed.transform.position;
              //  pressed.transform.position = entered.transform.position;
              //  entered.transform.position = pos;


               // int tmp = shuffled.IndexOf(pressed.ind);
               // int tmp1 = shuffled.IndexOf(entered.ind);

                int tmp2 = pressed.ind;
                pressed.ind = entered.ind;
                entered.ind = tmp2;

                Sprite sprite = entered.image.sprite;
                entered.image.sprite = pressed.image.sprite;
                pressed.image.sprite = sprite;

              //  shuffled[tmp1] = entered.ind;
              //  shuffled[tmp] = pressed.ind;


               // string s = "";
               // for (int i = 0; i < shuffled.Count; i++) s += shuffled[i] + " ";
               // print(s);
                //print(tmp + " " + tmp1 + " " + pressed.ind + " " + shuffled[tmp1]);
            }
        }
    }

    public void Pressed(Item item)
    {
       if(started) pressed = item;
    }

    public void Enter(Item item)
    {
       if(started) entered = item;
    }

    public void start()
    {
        print(started + " " + end);
        if(!started && !end)
        {
            started = true;
            label.text = "GUESS THE ORDER";
            shuffled = new List<int>();
            for (int i = 0; i < list.Count; i++) shuffled.Add(list[i]);
            shuffled.Shuffle();
            button.image.sprite = ready;
            if (level == 0)
            {
                for (int i = 0; i < easy.Length; i++)
                {
                    easy[i].image.sprite = sprites[shuffled[i]];
                    easy[i].ind = shuffled[i];
                }
            }
            else if (level == 1)
            {
                for (int i = 0; i < middle.Length; i++)
                {
                    middle[i].image.sprite = sprites[shuffled[i]];
                    middle[i].ind = shuffled[i];
                }
            }
            else
            {
                for (int i = 0; i < hard.Length; i++)
                {
                    hard[i].image.sprite = sprites[shuffled[i]];
                    hard[i].ind = shuffled[i];
                }
            }
        } else if(started && !end)
        {
            end = true;
            win = true;
            if(level==0)
            {
                for (int i = 0; i < easy.Length; i++)
                {
                    if (list[i] != easy[i].ind) win = false;
                }

            } else if(level==1)
            {
                for (int i = 0; i < middle.Length; i++)
                {
                    if (list[i] != middle[i].ind) win = false;
                }
            } else
            {
                for (int i = 0; i < hard.Length; i++)
                {
                    if (list[i] != hard[i].ind) win = false;
                }
            }
            if (win) winS.PlayOneShot(winS.clip);
            else loseS.PlayOneShot(loseS.clip);
            endlabel.text = win ? "GREAT!!!" : "GAME OVER";
            endframe.SetActive(true);
            button.image.sprite = win ? next : again;
            endscore.text = win ? "" : "";
            stars.SetActive(win);
        }  else if(end)
        {
            if(win)
            {
                level++;
                level = Mathf.Min(level, 2);
                PlayerPrefs.SetInt("level", level);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene(6);
        }
    }

}
