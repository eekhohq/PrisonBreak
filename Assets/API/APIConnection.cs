using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class APIConnection : MonoBehaviour
{
    public List<string> jokes = new List<string>();
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
                    //Debug.Log("Received: " + webRequest.downloadHandler.text);
                    JSONNode JsonObject = JSON.Parse(webRequest.downloadHandler.text);
                    
                    
                    
                    Debug.Log("Joke: " + JsonObject["value"]["joke"].Value);
                    if (jokes.Contains(JsonObject["value"]["joke"].Value))
                    {
                        break;
                    }
                    else
                    {
                        jokes.Add(JsonObject["value"]["joke"].Value);
                    }
                    break;
            }
        }
    }

    void Start()
    {
        StartCoroutine(GetRequest("http://api.icndb.com/jokes/random"));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(GetRequest("http://api.icndb.com/jokes/random"));
        }
    }
}
