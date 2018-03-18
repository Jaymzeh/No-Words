using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int sequenceIndex = 0;

    [SerializeField]
    public WordSequence[] sequences;

    
    
    public int sequenceState;

    public Checkerboard checkerPuzzle;
    public CrowdControl crowdPuzzle;
    public Silhouette silPuzzle;
    public Checkerboard checkerPuzzle2;
    public FinalPhrase phrasePuzzle;

    public static PuzzleBase[] puzzles;

    public Animator cameraState;
    public Animator hallAnim;

    void Awake() {
        Instance = this;
    }

    void Start() {

        if (checkerPuzzle != null) {
            checkerPuzzle.images[0].sprite = sequences[sequenceIndex].checkerImages[0];
            checkerPuzzle.images[1].sprite = sequences[sequenceIndex].checkerImages[1];
        }

        if (crowdPuzzle != null) {
            crowdPuzzle.wordImages[0].sprite = sequences[sequenceIndex].crowdImages[0];
            crowdPuzzle.wordImages[1].sprite = sequences[sequenceIndex].crowdImages[1];
        }

        if (silPuzzle != null) {
            silPuzzle.targetRotation = sequences[sequenceIndex].targetRotation;
        }

        if (checkerPuzzle2 != null) {
            checkerPuzzle2.images[0].sprite = sequences[sequenceIndex].checkerImages2[0];
            checkerPuzzle2.images[1].sprite = sequences[sequenceIndex].checkerImages2[1];
        }

        puzzles = new PuzzleBase[5];
        puzzles[0] = checkerPuzzle;
        puzzles[1] = crowdPuzzle;
        puzzles[2] = silPuzzle;
        puzzles[3] = checkerPuzzle2;
        puzzles[4] = phrasePuzzle;

        crowdPuzzle.gameObject.SetActive(false);

        GameObject meshObject = (GameObject)Instantiate(sequences[sequenceIndex].mesh, new Vector3(-7.5f, 1.6f, 20), Quaternion.identity);
        
        silPuzzle.shadowObject = meshObject.transform;
        
        silPuzzle.gameObject.SetActive(false);
    }

    public static void UpdateState() {
        puzzles[Instance.sequenceState].gameObject.SetActive(false);

        Instance.sequenceState ++;
        Instance.hallAnim.SetInteger("OpenDoor", Instance.sequenceState);
        Instance.cameraState.SetInteger("State", Instance.sequenceState);

        if (Instance.sequenceState >= 5) {
            Debug.Log("ALL PUZZLES COMPLETE");
            return;
        }
        Instance.StartCoroutine("ShowPuzzle");
        //puzzles[Instance.sequenceState].gameObject.SetActive(true);
    }

    IEnumerator ShowPuzzle() {
        if (Instance.sequenceState != 4) {
            yield return new WaitForSeconds(2);
            puzzles[Instance.sequenceState].gameObject.SetActive(true);
            
        }
        else
            puzzles[Instance.sequenceState].gameObject.SetActive(true);
    }

}

[System.Serializable]
public class WordSequence {
    public string[] words;

    public string phrase;

    public Sprite[] checkerImages;
    public Sprite[] crowdImages;
    public GameObject mesh;
    public Vector3 targetRotation;
    public Sprite[] checkerImages2;
}