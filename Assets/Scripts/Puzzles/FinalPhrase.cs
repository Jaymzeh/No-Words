using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPhrase : PuzzleBase {

    public Text text;
    int wordIndex = 0;

    string[] possibleWords;
    

    public struct Space {
        public string word;
        public int currentIndex;
        public int spaceIndex;
    }

    Space[] spaces;

    // Use this for initialization
    void Start() {

        text.text = GameManager.Instance.sequences[GameManager.sequenceIndex].phrase;
        possibleWords = new string[4];
        spaces = new Space[4];
        string temp = text.text;
        for(int i=0; i < 4; i++) {
            
            possibleWords[i] = "<color=blue>" + GameManager.Instance.sequences[GameManager.sequenceIndex].words[i] + "</color>";
            char[] tempWord = possibleWords[i].ToCharArray();
            

            spaces[i].currentIndex = Random.Range(0,3);
            spaces[i].spaceIndex = i;
            spaces[i].word = possibleWords[spaces[i].currentIndex];

            temp = temp.Replace(i.ToString(), spaces[i].word);
        }
        text.text = temp;
    }

    void CycleWord(int index) {
        int lastIndex = spaces[index].currentIndex;
        spaces[index].currentIndex++;
        if (spaces[index].currentIndex > 3)
            spaces[index].currentIndex = 0;

        spaces[index].word = possibleWords[spaces[index].currentIndex];

        string temp = GameManager.Instance.sequences[GameManager.sequenceIndex].phrase;

        for (int i = 0; i < 4; i++) {
            temp = temp.Replace(i.ToString(), spaces[i].word);
        }

        text.text = temp;
    }

    protected override bool CanSolve() {
        int i = 0;

        while (i < 4) {
            if (spaces[i].word.Contains(GameManager.Instance.sequences[GameManager.sequenceIndex].words[i]))
                i++;
            else break;
        }

        if (i == 4)
            return true;
        return false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
            CycleWord(0);
        if (Input.GetKeyDown(KeyCode.F2))
            CycleWord(1);
        if (Input.GetKeyDown(KeyCode.F3))
            CycleWord(2);
        if (Input.GetKeyDown(KeyCode.F4))
            CycleWord(3);

        if (Input.GetAxis("Submit") != 0) {
            if (CanSolve())
                Debug.Log("SOLVED");
            else
                Debug.Log("Not solved");
        }
	}
}