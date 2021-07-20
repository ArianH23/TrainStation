using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new PrintMessage", menuName = "FSM/Action/Print Message")]
public class PrintMessage : FSMaction {

	public string message;
	public string messageEnglish;
	public float duration;

	public override void Act(FSMcontroller controller) {
		int size = 125;
		if (Language.instance.English())
		{
			if (messageEnglish.Length > 26)	size = 100;
			MessageVR.PrintMessage(messageEnglish, duration, size);
		}
		else
		{
			MessageVR.PrintMessage(message, duration, size);
		}
	}

}
