using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Language
    {
        English,
        Hungarian
    }

public class LocalizationSystem : MonoBehaviour
{
        public Language state;
        public static Language language;

    public void GetEnumState(LocalizationSystem g)
    {
        language=g.state;
    }


 


    //dictionaries for the eng/hu values
    private static Dictionary<string, string> localizedEN;
    private static Dictionary<string, string> localizedHU;


    //initializing all values
    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();
        //reading the data from csv file, and assingning the data to the dictionaries
        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedHU = csvLoader.GetDictionaryValues("hu");
        //values loaded
        isInit = true;

    }
    //returns value based on the passed key
    public static string GetLocalisedValue(string key)
    {
        //initialize if not
        if(!isInit) {Init();}

        string value = key;

        switch (language)
        {
            case Language.English:
                localizedEN.TryGetValue(key, out value);
                break;
            case Language.Hungarian:
                localizedHU.TryGetValue(key, out value);
                break;
        }

        return value;
    }

}
