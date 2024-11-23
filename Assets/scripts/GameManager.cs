using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject mainMenuWriting;
    public GameObject game;
    public GameObject endScreen;
    public GameObject endScore;
    public GameObject[] whichRes;
    public GameObject[] gamePanels;
    public GameObject[] cardPanels;
    public GameObject[] endKingdom;
    public APIManager api;
    public CardSwipe cS;
    public void StartGame()
    {
        GetComponent<AudioSource>().Play();
        mainmenu.SetActive(false);
        game.SetActive(true);
        for (int i = 0; i < gamePanels.Length; i++)
        {
            gamePanels[i].SetActive(false);
            cardPanels[i].SetActive(false);
            endKingdom[i].SetActive(false);
        }
        gamePanels[api.profileNumber].SetActive(true);
        cardPanels[api.profileNumber].SetActive(true);
        StartCoroutine(api.GetScenarioFromAPI());
    }
    public void Profile(int prof) 
    {
        api.profileNumber = prof;
    }
    public void EndGame(int res,int type)
    {
        endKingdom[api.profileNumber].SetActive(true);
        endScore.GetComponent<TextMeshProUGUI>().text = cS.yearCounter.GetComponent<TextMeshProUGUI>().text;
        mainmenu.SetActive(false);
        game.SetActive(false);
        endScreen.SetActive(true);
        whichRes[res].transform.GetChild(type).gameObject.SetActive(true);
    }
    public void Restart()
    {
        for (int i = 0; i < cS.resImage.Length; i++)
        {
            gamePanels[i].SetActive(false);
            cardPanels[i].SetActive(false);
            endKingdom[i].SetActive(false);
            cS.resImage[i].GetComponent<Image>().fillAmount = 0.5f;
        }
        cS.yearCounter.GetComponent<TextMeshProUGUI>().text = "0";
        mainmenu.SetActive(true);
        game.SetActive(false);
        endScreen.SetActive(false);
    }
    private void Update()
    {
        if (api.profileNumber == 0)
        {
            mainMenuWriting.GetComponent<TextMeshProUGUI>().text = "SEÇÝLEN KRALLIK ÇÖL";
        }
        else if (api.profileNumber == 1)
        {
            mainMenuWriting.GetComponent<TextMeshProUGUI>().text = "SEÇÝLEN KRALLIK VÝKÝNG";
        }
        else if (api.profileNumber == 2)
        {
            mainMenuWriting.GetComponent<TextMeshProUGUI>().text = "SEÇÝLEN KRALLIK ORTAÇAÐ";
        }
        else if (api.profileNumber == 3)
        {
            mainMenuWriting.GetComponent<TextMeshProUGUI>().text = "SEÇÝLEN KRALLIK SAMURAY";
        }
        else
        {
            mainMenuWriting.GetComponent<TextMeshProUGUI>().text = "SEÇÝLEN KRALLIK BULUNMUYOR";
        }


 
    }


}
