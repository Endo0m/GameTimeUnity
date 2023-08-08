using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class GameInput : MonoBehaviour
{

    [SerializeField] private float TimeStart = 30;

    [SerializeField] private int wantPinOne = 5;
    [SerializeField] private int wantPinTwo = 5;
    [SerializeField] private int wantPinThree = 5;
  
    public Text pinOne;
    [SerializeField] private float scorePinOne = 4;
 
    public Text pinTwo;
    [SerializeField] private float scorePinTwo = 6;

    public Text pinThree;
    [SerializeField] private float scorePinThree = 5;

    public Text timerText;
    private float currentTime;
   

    [SerializeField] private Text winText;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private Text loseText;
    [SerializeField] private GameObject losePanel;
    private float min = 1;
    private float max = 10;

    public Image panelImage;
    public Sprite gold;
    public Sprite chest;
    public Sprite die;

    [SerializeField] private GameObject mkey;
    [SerializeField] private GameObject hammer;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject pin;
    [SerializeField] private GameObject scroll;
    [SerializeField] private GameObject timer;

    



   
    void Start()
    {
        timerText.text = TimeStart.ToString();
        pinOne.text = scorePinOne.ToString();
        pinTwo.text = scorePinTwo.ToString();
        pinThree.text = scorePinThree.ToString();

    }
    void Update()
    {

        scorePinOne = Mathf.Clamp(scorePinOne, min, max);
        scorePinTwo = Mathf.Clamp(scorePinTwo, min, max);
        scorePinThree = Mathf.Clamp(scorePinThree, min, max);


        pinOne.text = scorePinOne.ToString();
        pinTwo.text = scorePinTwo.ToString();
        pinThree.text = scorePinThree.ToString();

        if (scorePinOne == wantPinOne && scorePinTwo == wantPinTwo && scorePinThree == wantPinThree)
        {
            
            WinState();
        
        }
        else if(TimeStart == 25)
        {
              LoseState();
        }

        Timer();
        
    }
   
    public void OnLeftButtonClicked()
        {
            scorePinOne++;
            scorePinTwo--;
        }
        public void OnCentreButtonClicked()
        {
            
            scorePinOne--;
            scorePinTwo+=2;
            scorePinThree--;
        }
        public void OnRightButtonClicked()
        {
            scorePinOne--;
            scorePinTwo++;
            scorePinThree++;
        }

    private void Timer()
    {
        TimeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(TimeStart).ToString();
        if(TimeStart <= 0)
        {
            LoseState();
        }
    }

     private void WinState()
    {   
        winPanel.SetActive(true);
        winText.text = "Вы победили"; 
        Time.timeScale = 0;  
        panelImage.sprite = gold;
        mkey.SetActive(false);
        hammer.SetActive(false);
        knife.SetActive(false);
        pin.SetActive(false);
        scroll.SetActive(false);
        timer.SetActive(false);

    }

    private void LoseState()
    {   
        losePanel.SetActive(true);
        loseText.text = "Вы проиграли"; 
        Time.timeScale = 0;   
        panelImage.sprite = die;
        mkey.SetActive(false);
        hammer.SetActive(false);
        knife.SetActive(false);
         pin.SetActive(false);
        scroll.SetActive(false);
        timer.SetActive(false);

    }

    public void Restart()
    {
        Time.timeScale = 1;  
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        scorePinOne = 4;
        scorePinTwo = 6;
        scorePinThree = 5;
        TimeStart = 30;
        panelImage.sprite = chest;
    
        mkey.SetActive(true);
        hammer.SetActive(true);
        knife.SetActive(true);
         pin.SetActive(true);
        scroll.SetActive(true);
        timer.SetActive(true);
    }

}
