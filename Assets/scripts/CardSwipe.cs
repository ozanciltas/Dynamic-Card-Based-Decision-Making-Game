using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using DG;


public class CardSwipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 initialPos;
    Vector2 currentPos;
    public GameObject Card;
    Vector2 cardPos;
    Quaternion cardRot;
    Camera maincamera;
    float swipeForce;
    float rotationForce;
    public int[] resources = new int[4]; 
    public int[] resources2 = new int[4]; 

    public GameObject[] Indicators;
    public GameObject[] resImage;


    public GameManager gameManager;
    public ScenarioResponse scenarioResponse;
    public APIManager apý;
    public GameObject yearCounter;
    int year;
    public bool canSwipe = false;

    private void Start()
    {
        cardPos = Card.transform.position;
        cardRot = Card.transform.rotation;
        maincamera = Camera.main;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = maincamera.ScreenToWorldPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canSwipe == true)
        {
            currentPos = maincamera.ScreenToWorldPoint(eventData.position);
            swipeForce = (currentPos.x - initialPos.x);
            rotationForce = (currentPos.x - initialPos.x) * 4;
            Card.transform.position = new Vector2(Mathf.Clamp(cardPos.x + swipeForce, -1.75f, 1.75f), Card.transform.position.y);
            Card.transform.rotation = Quaternion.Lerp(Card.transform.rotation, Quaternion.Euler(0, 0, -rotationForce), Time.deltaTime * 200);
            if (currentPos.x < initialPos.x && Card.transform.position.x < -.20f)
            {
                ShowIndicator(resources);

            }
            else if (currentPos.x > initialPos.x && Card.transform.position.x > .20f)
            {
                ShowIndicator(resources2);
            }
            else
            {
                for (int i = 0; i < Indicators.Length; i++)
                {
                    Indicators[i].SetActive(false);
                }
            }
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (Card.transform.position.x>1.20f)
        {
            canSwipe = false;
            OnAction(resources2);
            Card.SetActive(false);
            Card.transform.position = cardPos;
            Card.transform.rotation = cardRot;
            StartCoroutine(apý.GetScenarioFromAPI());

            for (int i = 0; i < Indicators.Length; i++)
            {
                Indicators[i].gameObject.SetActive(false);
            }
            apý.eventText.GetComponent<TextMeshProUGUI>().text = "Bir Olay Olmasý Bekleniyor...";
            apý.effect1Text.GetComponent<TextMeshProUGUI>().text = "";
            apý.effect2Text.GetComponent<TextMeshProUGUI>().text = "";
            year += 2;
            yearCounter.GetComponent<TextMeshProUGUI>().text = year.ToString();
        }
        else if (Card.transform.position.x < -1.20f)
        {
            canSwipe = false;
            OnAction(resources);
            Card.SetActive(false);

            Card.transform.position = cardPos;
            Card.transform.rotation = cardRot;
            StartCoroutine(apý.GetScenarioFromAPI());
            for (int i = 0; i < Indicators.Length; i++)
            {
                Indicators[i].gameObject.SetActive(false);
            }
            apý.eventText.GetComponent<TextMeshProUGUI>().text = "Bir Olay Olmasý Bekleniyor...";
            apý.effect1Text.GetComponent<TextMeshProUGUI>().text = "";
            apý.effect2Text.GetComponent<TextMeshProUGUI>().text = "";
            year += 2;
            yearCounter.GetComponent<TextMeshProUGUI>().text = year.ToString();
        }
        else
        {
            Card.transform.position = cardPos;
            Card.transform.rotation = cardRot;
        }

        for (int i = 0; i < resImage.Length; i++)
        {
            if (resImage[i].GetComponent<Image>().fillAmount == 0 )
            {
                gameManager.EndGame(i, 0);
            }
            else if (resImage[i].GetComponent<Image>().fillAmount == 1)
            {
                gameManager.EndGame(i, 1);
            }       
        }

    }
    public void ShowIndicator(int[] res)
    {

        for (int i = 0; i < res.Length; i++)
        {
            if (res[i] != 0)
            {
                Indicators[i].gameObject.SetActive(true);
            }
            else
            {
                Indicators[i].gameObject.SetActive(false);
            }
        }
    }
    public void OnAction(int[] res)
    {

        for (int i = 0; i < res.Length; i++)
        {
            if (res[i] == 1)
            {
                resImage[i].GetComponent<Image>().fillAmount += 0.15f;
                Color origin = resImage[i].GetComponent<Image>().color;
                resImage[i].GetComponent<Image>().color = Color.green;
                resImage[i].GetComponent<Image>().DOColor(origin, 1.5f);
            }
            else if (res[i] == -1)
            {
                resImage[i].GetComponent<Image>().fillAmount -= 0.15f;
                Color origin = resImage[i].GetComponent<Image>().color;
                resImage[i].GetComponent<Image>().color = Color.red;
                resImage[i].GetComponent<Image>().DOColor(origin, 1.5f);
            }
            else
            {

            }
        }

    }
    public void ApplyEffects(Effects eff, int[] res)
    {
        for (int i = 0; i < res.Length; i++)
        {
            if (eff[i] == "artar" || eff[i] == "Artar" || eff[i] == "Artabilir" || eff[i] == "artabilir")
            {
                res[i] = 1;
            }
            else if (eff[i] == "azalýr" || eff[i] == "Azalýr" || eff[i] == "Azalabilir" || eff[i] == "azalabilir")
            {
                res[i] = -1;
            }
            else
            {
                res[i] = 0;
            }
        }

    }


}
