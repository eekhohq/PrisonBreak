using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;


public class APIUIHandler : MonoBehaviour
{
    public GameObject text;
    public InputField inputField;
    public string fetched;
    public string modified = "lolgitfucked";
    public GameObject door;

    private IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    fetched = webRequest.downloadHandler.text;
                    text.GetComponent<Text>().text = fetched;
                    string[] allWords = fetched.Split();
                    modified = allWords[0];
                    break;
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetRequest("http://numbersapi.com/random"));
    }

    public void ValueChangeCheck(string input)
    {
        Debug.Log(input);
        if (input == modified)
        {
            door.GetComponent<Door>().ActionWithoutCheck();
        }
    }
}
