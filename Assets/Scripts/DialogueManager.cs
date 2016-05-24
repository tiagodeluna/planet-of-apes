using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager instance = null;	//Allows other scripts to call functions from SoundManager.             
	public GameObject dialogueBox;					//Box that contains the dialogueText.
	public Text dialogueText;						//Element that shows the dialogue texts.
	public bool dialogueActive;						//Stores the status of Dialogue Box.
	public float dialogueStartDelay = 3f;

	Dictionary<int, string> dialogueMap;

	// Use this for initialization
	void Awake () {
		//Check if there is already an instance of SoundManager
		if (instance == null) {
			//if not, set it to this.
			instance = this;

			//Initializes list of dialogue texts.
			dialogueMap = new Dictionary<int, string> ();
			dialogueMap.Add(1, "I can't believe I survived the fall!\nThe controls of my ship just went crazy " +
				"and I was attracted by the gravitational field of this planet... but what planet is this?");
			dialogueMap.Add(2, "My God! There are apes here!");
		}
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy(gameObject);

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
		{
			dialogueActive = false;
			dialogueBox.SetActive (false);
		}
	}

	public void ShowBox(int level)
	{
		//Selects the text for the current level to be displayed.
		string text;
		dialogueMap.TryGetValue (level, out text);

		if (!string.IsNullOrEmpty (text)) {
			//Call the SetActive function with a delay in seconds of dialogueStartDelay.
			Invoke ("SetActive", dialogueStartDelay);
			dialogueText.text = text;
		}

	}

	void SetActive()
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
	}
}
