﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SayWithNoConditionArray", menuName = "FSM/Action/Say With No Condition Array")]

public class SayWithNoConditionArray : FSMaction
{
    public AudioClip[] audioF;
    public AudioClip[] audioM;

    public AudioClip[] audioFEnglish;
    public AudioClip[] audioMEnglish;

    public string text;
    public string textEnglish;

    public override void Act(FSMcontroller controller)
    {
        controller.GetComponent<Interaction>().Say(audioF, audioM);
        VoiceRecognizer.instance.startedAnalysis = false;
        ConversationText.instance.StoreSentence(false, text);
    }
}
