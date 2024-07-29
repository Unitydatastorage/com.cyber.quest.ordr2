using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] Game game;
    public int ind;
    [SerializeField] public Image image;

    // Start is called before the first frame update
    void Start()
    {
       // image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInd(int i)
    {

    }

    public void enter()
    {
        game.Enter(this);
    }
    public void pressed()
    {
        game.Pressed(this);
    }

    public void up()
    {
        game.up();
    }
}
