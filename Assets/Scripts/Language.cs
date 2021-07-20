using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public enum Languages
    {
        English,
        Spanish
    }

    public Languages language;
    public static Language instance;

    void Start()
    {
        if (Language.instance) Destroy(this);
        Language.instance = this;
    }

    public bool English()
    {
        return Language.instance.language == Language.Languages.English;
    }
}