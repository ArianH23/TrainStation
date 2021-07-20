using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WordOR", menuName = "FSM/Decision/Word OR")]
public class WordOR : FSMdecision
{
	public string[] words;
	public string[] wordsEnglish;

	public override bool Decide(FSMcontroller controller)
	{
		if (SentenceAnalyzer.instance.sentence != null)
		{
			string sentence = SentenceAnalyzer.instance.sentence;

			if (Language.instance.English())
			{
				foreach (string word in wordsEnglish)
				{
					if (sentence.Contains(word)) return true;
				}
			}

			else
			{
				foreach (string word in words)
				{
					if (sentence.Contains(word)) return true;
				}
			}
		}
		return false;
	}
}
