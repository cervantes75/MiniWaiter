using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CSVLoader : MonoBehaviour
{
    private TextAsset csvFile; //reference to file
    private char lineSeparator = '\n';
    private char surround = '"';
    private string[] fieldSeparator = {"\",\""};

    //load & assign the csv
    public void LoadCSV()
    {
        csvFile = Resources.Load<TextAsset>("localization");
    }
    //passer function
    //dictionary stores elements
    
    public Dictionary<string, string> GetDictionaryValues(string attributeId)
    {
        //break up the text file to lines
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csvFile.text.Split(lineSeparator);

        int attributeIndex = -1;
        //identify the language
        string[] headers = lines[0].Split(fieldSeparator, System.StringSplitOptions.None);

        
        for(int i=0; i<headers.Length; i++)
        {
            if(headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                break;
            }
        }
    //line split
    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

    for(int i=1; i<lines.Length; i++)
    {
        string line = lines[i];
        string[] fields = CSVParser.Split(line);

        for(int f=0; f<fields.Length; f++)
        {
            fields[f] = fields[f].TrimStart(' ', surround);
            fields[f] = fields[f].TrimEnd(surround);
        }

        //assing the key
        if(fields.Length > attributeIndex)
        {
            var key = fields[0];

            if (dictionary.ContainsKey(key)) {continue;}

            var value = fields[attributeIndex];

            dictionary.Add(key, value);

        }
    }

    return dictionary;

    }
}
