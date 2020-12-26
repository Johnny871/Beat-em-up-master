using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    private Image startsprite;
    [SerializeField] GameObject startbuttonobj;
    [SerializeField] private Sprite startbuttonup;
    [SerializeField] private Sprite startbuttondown;

    private Image optionsprite;
    [SerializeField] GameObject optionbuttonobj;
    [SerializeField] private Sprite optionbuttonup;
    [SerializeField] private Sprite optionbuttondown;

    private Image exitsprite;
    [SerializeField] GameObject exitbuttonobj;
    [SerializeField] private Sprite exitbuttonup;
    [SerializeField] private Sprite exitbuttondown;

    // Start is called before the first frame update
    void Start()
    {
        startsprite = startbuttonobj.GetComponent<Image>();
        optionsprite = optionbuttonobj.GetComponent<Image>();
        exitsprite = exitbuttonobj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton(){
        Debug.Log("Startボタンが押された");
    }

    public void PointDownStartButton(){
        startsprite.sprite = startbuttondown;
    }

    public void PointUpStartButton(){
        startsprite.sprite = startbuttonup;
    }

    public void OnClickOptionButton(){
        Debug.Log("Optionボタンが押された");
    }

    public void PointDownOptionButton(){
        optionsprite.sprite = optionbuttondown;
    }

    public void PointUpOptionButton(){
        optionsprite.sprite = optionbuttonup;
    }

    public void OnClickExitButton(){
        Debug.Log("Exitボタンが押された");
    }

    public void PointDownExitButton(){
        exitsprite.sprite = exitbuttondown;
    }

    public void PointUpExitButton(){
        exitsprite.sprite = exitbuttonup;
    }

}
