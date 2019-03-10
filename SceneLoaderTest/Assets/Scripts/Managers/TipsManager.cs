using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JSONs;

public class TipsManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI tipsTextUI;


    private void OnEnable()
    {
        LoadTextFile();
        ParseText();
        PopulateTextUI();
    }
    #region UI Populating

    private void PopulateTextUI()
    {
        tipsTextUI.text = RandomText();
    }

    /// <summary>
    /// Picks a random quote from the array
    /// </summary>
    /// <returns></returns>
    private string RandomText()
    {
        string result = string.Empty;
        int k = quotes.Length;
        int c = Random.Range(0, k);
        
        result=quotes[c];
        return result;

    }
    #endregion

    #region Text loading and parsing
    private TextAsset TextFile;
    private string[] quotes;
    private TipsJson localTipsJson;

    private void LoadTextFile()
    {
        TextFile=Resources.Load("tips") as TextAsset;
    }

    private void ParseText()
    {
        localTipsJson = new TipsJson();
        localTipsJson=JsonUtility.FromJson<TipsJson>(TextFile.text);
        quotes = localTipsJson.quotes;

    }
    #endregion


}
