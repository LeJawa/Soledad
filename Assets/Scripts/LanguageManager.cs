using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum Language {
    EN,
    ES
}

public static class LanguageManager {

    static bool _initialized = false;

    static Dictionary<Language, Dictionary<string, string>> _dic;

    static Language _currentLanguage;

    public static void Initialize(Language language) {

        _currentLanguage = language;

        if ( _initialized ) {
            return;
        }

        _dic = new Dictionary<Language, Dictionary<string, string>>();

        _dic.Add(Language.EN, new Dictionary<string, string>());
        _dic.Add(Language.ES, new Dictionary<string, string>());


        StreamReader input = null;
        try {
            input = File.OpenText(Application.streamingAssetsPath + @"\text.csv");

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

    }

    static void AddNewTextLine(string csvString) {
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

    public static string GetTextFromKey(string key) {
        if ( _initialized ) {
            return _dic[_currentLanguage][key];
        }
        else {
            return "";
        }
    }

}
