using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreText : MonoBehaviour
{
    GameManager gM;

    public TMP_Text gameOverScoreText;

    void Awake()
    {
        gM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); //get GameManager GameObject on the start of the Scene
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScoreText.text = "Score: " + gM.playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
