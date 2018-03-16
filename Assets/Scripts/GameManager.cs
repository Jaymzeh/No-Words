using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    public WordSequence[] sequences;
    public int sequenceGroupIndex = 0;
    public int sequenceIndex;
    
    void Start() {
        FindObjectOfType<Silhoutte>().targetRotation = sequences[sequenceGroupIndex].targetRotation;
    }

}

[System.Serializable]
public class WordSequence {
    public string[] words;

    public Sprite[] checkerImages;
    public Sprite[] crowdImages;
    public GameObject mesh;
    public Vector3 targetRotation;
}