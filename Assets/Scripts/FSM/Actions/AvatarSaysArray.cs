﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AvatarSaysArray", menuName = "FSM/Action/Avatar Says Array")]

public class AvatarSaysArray : FSMaction
{
    public AudioClip[] audioF;
    public AudioClip[] audioM;
    public AudioClip[] audioFEnglish, audioMEnglish;
    public string text;
    public string textEnglish;

    public override void Act(FSMcontroller controller)
    {
        if (VoiceRecognizer.instance.startedAnalysis)
        {
            if (condition == null || condition.Decide(controller))
            {
                if (Language.instance.English())
                {
                    controller.GetComponent<Interaction>().Say(audioFEnglish, audioMEnglish);
                    ConversationText.instance.StoreSentence(false, textEnglish);
                }
                else
                {
                    controller.GetComponent<Interaction>().Say(audioF, audioM);
                    ConversationText.instance.StoreSentence(false, text);
                }
                VoiceRecognizer.instance.startedAnalysis = false;
                
            }
        }
    }
}

