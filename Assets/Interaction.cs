﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public AudioSource audioSource;
    bool isFemale;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isFemale = transform.name.Contains("F");
    }


    public void AnswerQuestion(int answer) {
        if (isFemale)
        {
            AudioClip ac = VoiceAnswers.instance.female[answer];
            audioSource.PlayOneShot(ac);
        }
        else
        {
            AudioClip ac = VoiceAnswers.instance.male[answer];
            audioSource.PlayOneShot(ac);
        }
    }
}
