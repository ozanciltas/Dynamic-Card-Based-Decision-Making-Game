using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
    private string apiUrl = "URL"; // API endpoint URL
    private string apiKey = "Your Key"; // Your API key

    public CardSwipe cardSwipe;
    public GameObject eventText;
    public GameObject effect1Text;
    public GameObject effect2Text;


    public Effects effect1;
    public Effects effect2;

    public int profileNumber = 4;
    
    public IEnumerator GetScenarioFromAPI()
    {
        string prompt;
        if (profileNumber == 0)
        {
            prompt = "Bana bir ��l krall���n�n y�neticisi olarak oynad���m oyunda, krall���n ba��na gelebilecek bir olay senaryosu olu�tur maksimum 2 c�mle uzunlu�unda olsun." +
            "Kral�n alabilece�i iki alternatif karar olu�tur. Bu kararlar�n oyun kaynaklar�na etkisini (etki etmez, artar, azal�r) belirt, bu etki kelimeleri d���nda ba�ka bir kelime kullanma. " +
            "Yan�t� JSON format�nda �u �ekilde d�nd�r: {" +
            "\\\"scenario\\\": \\\"<senaryo>\\\", " +
            "\\\"choice1\\\": \\\"<se�im1>\\\", " +
            "\\\"choice2\\\": \\\"<se�im2>\\\", " +
            "\\\"effect1\\\": {\\\"army\\\": \\\"<etki1-ordu>\\\", \\\"people\\\": \\\"<etki1-insanlar>\\\", \\\"church\\\": \\\"<etki1-kilise>\\\", \\\"wealth\\\": \\\"<etki1-zenginlik>\\\"}, " +
            "\\\"effect2\\\": {\\\"army\\\": \\\"<etki2-ordu>\\\", \\\"people\\\": \\\"<etki2-insanlar>\\\", \\\"church\\\": \\\"<etki2-kilise>\\\", \\\"wealth\\\": \\\"<etki2-zenginlik>\\\"}" +
            "}";
        }
        else if (profileNumber == 1)
        {
            prompt = "Bana bir Viking krall���n�n y�neticisi olarak oynad���m oyunda, krall���n ba��na gelebilecek bir olay senaryosu olu�tur maksimum 2 c�mle uzunlu�unda olsun." +
            "Kral�n alabilece�i iki alternatif karar olu�tur. Bu kararlar�n oyun kaynaklar�na etkisini (etki etmez, artar, azal�r) belirt, bu etki kelimeleri d���nda ba�ka bir kelime kullanma. " +
            "Yan�t� JSON format�nda �u �ekilde d�nd�r: {" +
            "\\\"scenario\\\": \\\"<senaryo>\\\", " +
            "\\\"choice1\\\": \\\"<se�im1>\\\", " +
            "\\\"choice2\\\": \\\"<se�im2>\\\", " +
            "\\\"effect1\\\": {\\\"army\\\": \\\"<etki1-ordu>\\\", \\\"people\\\": \\\"<etki1-insanlar>\\\", \\\"church\\\": \\\"<etki1-kilise>\\\", \\\"wealth\\\": \\\"<etki1-zenginlik>\\\"}, " +
            "\\\"effect2\\\": {\\\"army\\\": \\\"<etki2-ordu>\\\", \\\"people\\\": \\\"<etki2-insanlar>\\\", \\\"church\\\": \\\"<etki2-kilise>\\\", \\\"wealth\\\": \\\"<etki2-zenginlik>\\\"}" +
            "}";
        }
        else if (profileNumber == 2)
        {

            prompt = "Bana bir Orta�a� krall���n�n y�neticisi olarak oynad���m oyunda, krall���n ba��na gelebilecek bir olay senaryosu olu�tur maksimum 2 c�mle uzunlu�unda olsun." +
            "Kral�n alabilece�i iki alternatif karar olu�tur. Bu kararlar�n oyun kaynaklar�na etkisini (etki etmez, artar, azal�r) belirt, bu etki kelimeleri d���nda ba�ka bir kelime kullanma. " +
            "Yan�t� JSON format�nda �u �ekilde d�nd�r: {" +
            "\\\"scenario\\\": \\\"<senaryo>\\\", " +
            "\\\"choice1\\\": \\\"<se�im1>\\\", " +
            "\\\"choice2\\\": \\\"<se�im2>\\\", " +
            "\\\"effect1\\\": {\\\"army\\\": \\\"<etki1-ordu>\\\", \\\"people\\\": \\\"<etki1-insanlar>\\\", \\\"church\\\": \\\"<etki1-kilise>\\\", \\\"wealth\\\": \\\"<etki1-zenginlik>\\\"}, " +
            "\\\"effect2\\\": {\\\"army\\\": \\\"<etki2-ordu>\\\", \\\"people\\\": \\\"<etki2-insanlar>\\\", \\\"church\\\": \\\"<etki2-kilise>\\\", \\\"wealth\\\": \\\"<etki2-zenginlik>\\\"}" +
            "}";
        }
        else if (profileNumber == 3) 
        {
            prompt = "Bana bir samuray kral���n�n y�neticisi olarak oynad���m oyunda, krall���n ba��na gelebilecek bir olay senaryosu olu�tur maksimum 2 c�mle uzunlu�unda olsun." +
                "Kral�n alabilece�i iki alternatif karar olu�tur. Bu kararlar�n oyun kaynaklar�na etkisini (etki etmez, artar, azal�r) belirt, bu etki kelimeleri d���nda ba�ka bir kelime kullanma. " +
                "Yan�t� JSON format�nda �u �ekilde d�nd�r: {" +
                "\\\"scenario\\\": \\\"<senaryo>\\\", " +
                "\\\"choice1\\\": \\\"<se�im1>\\\", " +
                "\\\"choice2\\\": \\\"<se�im2>\\\", " +
                "\\\"effect1\\\": {\\\"army\\\": \\\"<etki1-ordu>\\\", \\\"people\\\": \\\"<etki1-insanlar>\\\", \\\"church\\\": \\\"<etki1-kilise>\\\", \\\"wealth\\\": \\\"<etki1-zenginlik>\\\"}, " +
                "\\\"effect2\\\": {\\\"army\\\": \\\"<etki2-ordu>\\\", \\\"people\\\": \\\"<etki2-insanlar>\\\", \\\"church\\\": \\\"<etki2-kilise>\\\", \\\"wealth\\\": \\\"<etki2-zenginlik>\\\"}" +
                "}";
        }
        else
        {
            prompt = "Bana bir kral���n y�neticisi olarak oynad���m oyunda, krall���n ba��na gelebilecek bir olay senaryosu olu�tur maksimum 2 c�mle uzunlu�unda olsun." +
            "Kral�n alabilece�i iki alternatif karar olu�tur. Bu kararlar�n oyun kaynaklar�na etkisini (etki etmez, artar, azal�r) belirt, bu etki kelimeleri d���nda ba�ka bir kelime kullanma. " +
            "Yan�t� JSON format�nda �u �ekilde d�nd�r: {" +
            "\\\"scenario\\\": \\\"<senaryo>\\\", " +
            "\\\"choice1\\\": \\\"<se�im1>\\\", " +
            "\\\"choice2\\\": \\\"<se�im2>\\\", " +
            "\\\"effect1\\\": {\\\"army\\\": \\\"<etki1-ordu>\\\", \\\"people\\\": \\\"<etki1-insanlar>\\\", \\\"church\\\": \\\"<etki1-kilise>\\\", \\\"wealth\\\": \\\"<etki1-zenginlik>\\\"}, " +
            "\\\"effect2\\\": {\\\"army\\\": \\\"<etki2-ordu>\\\", \\\"people\\\": \\\"<etki2-insanlar>\\\", \\\"church\\\": \\\"<etki2-kilise>\\\", \\\"wealth\\\": \\\"<etki2-zenginlik>\\\"}" +
            "}";
        }
        // API'ye g�nderece�imiz JSON payload
        
        string jsonPayload = "{\"contents\":[{\"parts\":[{\"text\":\"" + prompt + "\"}]}]}";
        string fullURL = apiUrl + "?key=" + apiKey;

        using (UnityWebRequest request = new UnityWebRequest(fullURL, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Server Response: " + jsonResponse);

                // Yan�t�n "text" alan�n� ay�klay�n ve tekrar JSON olarak ��z�mleyin
                ScenarioResponse scenarioResponse = ExtractScenarioResponse(jsonResponse);
                if (scenarioResponse != null)
                {
                    //Debug.Log("Senaryo: " + scenarioResponse.scenario);
                    cardSwipe.canSwipe = true;
                    eventText.GetComponent<TextMeshProUGUI>().text = scenarioResponse.scenario;
                    effect1Text.GetComponent<TextMeshProUGUI>().text = scenarioResponse.choice1;
                    effect2Text.GetComponent<TextMeshProUGUI>().text = scenarioResponse.choice2;
                    cardSwipe.Card.SetActive(true);
                    //Debug.Log("Se�im 1: " + scenarioResponse.choice1);
                    //Debug.Log("Se�im 2: " + scenarioResponse.choice2);
                    //Debug.Log("Etki 1: Army: " + scenarioResponse.effect1.army + ", People: " + scenarioResponse.effect1.people + ", Church: " + scenarioResponse.effect1.church + ", Wealth: " + scenarioResponse.effect1.wealth);
                    //Debug.Log("Etki 2: Army: " + scenarioResponse.effect2.army + ", People: " + scenarioResponse.effect2.people + ", Church: " + scenarioResponse.effect2.church + ", Wealth: " + scenarioResponse.effect2.wealth);
                    effect1 = scenarioResponse.effect1;
                    effect2 = scenarioResponse.effect2;
                    cardSwipe.ApplyEffects(effect1, cardSwipe.resources);
                    cardSwipe.ApplyEffects(effect2, cardSwipe.resources2);
                    // cardSwipe.UpdateCard(scenarioResponse.scenario, scenarioResponse.choice1, scenarioResponse.choice2, scenarioResponse.effect1, scenarioResponse.effect2);
                }

            }
        }
    }

    private ScenarioResponse ExtractScenarioResponse(string jsonResponse)
    {
        // Yan�t� ��z�mleyip "text" alan�n� ay�klay�n
        var fullResponse = JsonUtility.FromJson<FullResponse>(jsonResponse);
        if (fullResponse != null && fullResponse.candidates.Length > 0)
        {
            var textContent = fullResponse.candidates[0].content.parts[0].text;
            // "text" alan�n� tekrar JSON olarak ��z�mleyin
            return JsonUtility.FromJson<ScenarioResponse>(textContent);
        }
        return null;
    }
}

[System.Serializable]
public class FullResponse
{
    public Candidate[] candidates;
}

[System.Serializable]
public class Candidate
{
    public Content content;
}

[System.Serializable]
public class Content
{
    public Part[] parts;
}

[System.Serializable]
public class Part
{
    public string text;
}

[System.Serializable]
public class ScenarioResponse
{
    public string scenario;
    public string choice1;
    public string choice2;
    public Effects effect1;
    public Effects effect2;
}

[System.Serializable]
public class Effects
{
    public string army;
    public string people;
    public string church;
    public string wealth;

    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return army;
                case 1:
                    return people;
                case 2:
                    return church;
                case 3:
                    return wealth;
                default:
                    throw new System.IndexOutOfRangeException("Invalid Effects index");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    army = value;
                    break;
                case 1:
                    people = value;
                    break;
                case 2:
                    church = value;
                    break;
                case 3:
                    wealth = value;
                    break;
                default:
                    throw new System.IndexOutOfRangeException("Invalid Effects index");
            }
        }

    }

}