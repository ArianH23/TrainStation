using System.Collections;
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
