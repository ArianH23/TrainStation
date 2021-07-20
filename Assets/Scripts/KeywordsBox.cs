using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeywordsBox : MonoBehaviour
{
    public static KeywordsBox instance;
    private TMP_Text t;
    public TMP_Text askFor;
    WordOR[] arrayWithKeywords;
    List <string> wordsToBeDisplayed;

    void Awake()
    {
        if (KeywordsBox.instance) Destroy(this);
        KeywordsBox.instance = this;
        t = GetComponentInChildren<TMP_Text>();
        wordsToBeDisplayed = new List<string>();
        TurnXKeyWordDisplay(false);
    }

    private void Start()
    {
        if (Language.instance.English()) askFor.text = "Ask for:";
    }

    public void updateCurrentKeywords(WordOR[] array)
    {
        wordsToBeDisplayed.Clear();


        foreach (WordOR dec in array)
        {
            if(Language.instance.English())
            wordsToBeDisplayed.Add(dec.wordsEnglish[0]);

            else wordsToBeDisplayed.Add(dec.words[0]);

        }

        string text = "";
        foreach(string word in wordsToBeDisplayed)
        {
            text += word + "\n";
        }
        t.text = text;
    }

    public void TurnXKeyWordDisplay(bool OnOff)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(OnOff);
        }
    }
}
