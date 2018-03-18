using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPhrase : PuzzleBase {

    public Text text;
    int activeSpaceIndex = 0;

    string[] possibleWords;
    bool cycleAxisUsed = false;
    bool indexCycleUsed = false;

    public struct Space {
        public string word;
        public int currentIndex;
        public int spaceIndex;
    }

    Space[] spaces;

    // Use this for initialization
    void Start() {

        text.text = GameManager.Instance.sequences[GameManager.Instance.sequenceIndex].phrase;
        possibleWords = new string[5];
        possibleWords[4] = "<color=blue>_</color>";
        spaces = new Space[4];

        string temp = text.text;
        for(int i=0; i < 4; i++) {
            
            possibleWords[i] = "<color=blue>" + GameManager.Instance.sequences[GameManager.Instance.sequenceIndex].words[i] + "</color>";
            char[] tempWord = possibleWords[i].ToCharArray();
            

            spaces[i].currentIndex = 0;
            spaces[i].spaceIndex = i;
            spaces[i].word = possibleWords[4];

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

        string temp = GameManager.Instance.sequences[GameManager.Instance.sequenceIndex].phrase;

        for (int i = 0; i < 4; i++) {
            temp = temp.Replace(i.ToString(), spaces[i].word);
        }

        text.text = temp;
    }

    protected override bool CanSolve() {
        int i = 0;

        while (i < 4) {
            if (spaces[i].word.Contains(GameManager.Instance.sequences[GameManager.Instance.sequenceIndex].words[i]))
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
            if (!indexCycleUsed) {
                if (spaces[activeSpaceIndex].word.Contains(GameManager.Instance.sequences[GameManager.Instance.sequenceIndex].words[activeSpaceIndex])) {
                    activeSpaceIndex++;
                }

                if (CanSolve())
                    Debug.Log("SOLVED");
                else
                    Debug.Log("Not solved");

                indexCycleUsed = true;
            }
        }
        if (Input.GetAxis("Submit") == 0)
            indexCycleUsed = false;



        if (Input.GetAxisRaw("Cycle") != 0) {
            if (!cycleAxisUsed) {
                CycleWord(activeSpaceIndex);
                cycleAxisUsed = true;
            }
        }
        if (Input.GetAxisRaw("Cycle") == 0)
            cycleAxisUsed = false;
	}
}