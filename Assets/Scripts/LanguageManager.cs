using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public enum Language {
    EN,
    ES
}

public class LanguageManager : MonoBehaviour{

    #region SINGLETON PATTERN
    static LanguageManager current;
    public static LanguageManager Instance {
        get {
            if ( current == null ) {
                current = GameObject.FindObjectOfType<LanguageManager>();

                if ( current == null ) {
                    GameObject container = new GameObject("LanguageManager");
                    current = container.AddComponent<LanguageManager>();
                }
            }

            return current;
        }
    }
    #endregion

    static bool _initialized = false;
    bool _initializing = false;

    Dictionary<Language, Dictionary<string, string>> _dic;

    static Language _currentLanguage;


    public void Initialize(Language language) {

        _currentLanguage = language;

        if ( _initialized || _initializing ) {
            return;
        }

        _dic = new Dictionary<Language, Dictionary<string, string>>();

        _dic.Add(Language.EN, new Dictionary<string, string>());
        _dic.Add(Language.ES, new Dictionary<string, string>());

        string path = Application.streamingAssetsPath + @"/text.csv";

#if UNITY_STANDALONE
        StreamReader input = null;

        try {
            input = File.OpenText(path);


        input.ReadLine();

            while ( !input.EndOfStream ) {
                AddNewTextLine(input.ReadLine());
            }


            _initialized = true;
        }
        catch (System.Exception e ) {
            Debug.LogWarning(e.Message);
        }
        finally {
            if ( input != null ) {
                input.Close();
            }
        }


#endif
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_EDITOR
        UnityWebRequest www = UnityWebRequest.Get(path);

        _initializing = true;
        StartCoroutine(GetRequest(path, (UnityWebRequest req) => {
            if ( req.isNetworkError || req.isHttpError ) {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else {
                Debug.Log(req.downloadHandler.text);
                ParseUnityWebRequestText(req.downloadHandler.text);

                _initialized = true;

                GameEvents.Instance.TriggerFinishedLoadingLanguageManager();
            }
        }));
         
#endif

    }

    void ParseUnityWebRequestText(string unityWebRequestText) {

        // Lines are separated by \r\n
        // I first split by '\n'
        string[] lines = unityWebRequestText.Split('\n');


        for ( int i = 1; i < lines.Length - 1; i++ ) {
            // And then take the substring without the last '\r'
            AddNewTextLine(lines[i].Substring(0, lines[i].Length - 1)); ;
        }
    }

    IEnumerator GetRequest(string url, Action<UnityWebRequest> callback) {
        using ( UnityWebRequest request = UnityWebRequest.Get(url) ) {
            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    void AddNewTextLine(string csvString) {
        string[] texts = csvString.Split(';');

        try {
            string key = texts[0];

            _dic[Language.EN].Add(key, texts[1]);
            _dic[Language.ES].Add(key, texts[2]);

        }
        catch ( System.Exception e ) {
            Debug.LogWarning(e.Message);
        }
    }

    public string GetTextFromKey(string key) {
        if ( !_initialized ) {
            Initialize(GameController.Instance.Language);
            return _dic[_currentLanguage][key];
        }
        else {
            return _dic[_currentLanguage][key];
        }
    }

}
