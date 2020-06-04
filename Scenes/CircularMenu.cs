using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CircularMenu : MonoBehaviour
{

    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 mousePosition;
    private Vector2 fromVector2M = new Vector2(0.5f, 0f);
    private Vector2 centercircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M;

    public int menuItems;
    public int curMenuItem;
    private int oldMenuItem;

    // Start is called before the first frame update
    void Start()
    {

        menuItems = buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.sceneimage.color = button.NormalColor;

        }
        curMenuItem = 0;
        oldMenuItem = 0;

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentMenuItem();
        if (Input.GetButtonDown("Fire1"))
            ButtonAction();
        
    }

    public void GetCurrentMenuItem()
    {

        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        toVector2M = new Vector2(mousePosition.x / Screen.width, mousePosition.y / Screen.height);

        float angle = (Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) - Mathf.Atan2(toVector2M.y - centercircle.y, toVector2M.x - centercircle.x)) * Mathf.Rad2Deg;

        if (angle < 0)
            angle += 360;

        curMenuItem = (int) (angle / (360 / menuItems));

        if(curMenuItem != oldMenuItem)
        {
            
            buttons[oldMenuItem].sceneimage.color = buttons[oldMenuItem].NormalColor;
            oldMenuItem = curMenuItem;
            buttons[curMenuItem].sceneimage.color = buttons[curMenuItem].HighlightedColor;
            

        }
    }

    public void ButtonAction()
    {
        buttons[curMenuItem].sceneimage.color = buttons [curMenuItem].PressedColor;
        if (curMenuItem == 0)
            print("You have pressed the first button");
    }
}

[System.Serializable]
public class MenuButton
{
    public string name;
    public Image sceneimage;
    public Color NormalColor = Color.white;
    public Color HighlightedColor = Color.grey;
    public Color PressedColor = Color.gray;

}
