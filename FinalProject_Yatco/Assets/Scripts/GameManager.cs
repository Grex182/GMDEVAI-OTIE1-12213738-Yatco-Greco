using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float playerScore;

    public bool playerHasScored = false;

    public bool playerDead = false;

    public TMP_Text playerScoreText;

    public GameObject playerUI;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(playerUI);
        playerScoreText.text = "Score: " + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        ReturnToTitleScreen();

        PlayerScored();

        DestroyUIOnMenu();

        GameOverUI();
    }

    void ReturnToTitleScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerScore = 0;
            SceneManager.LoadScene(0);
        }
    }

    void PlayerScored()
    {
        if (playerHasScored)
        {
            playerScoreText.text = "Score: " + playerScore;
            SceneManager.LoadScene(Random.Range(3, 12)); //Randomize next scene based off of Random.Range (MAIN LINE OF CODE, UNCOMMENT IF WANT TO TEST ALL LEVELS OR GAME IS FINISHED)
//            SceneManager.LoadScene(3); //LEVEL1 (DONE)
//            SceneManager.LoadScene(4); //LEVEL2 (DONE)
//            SceneManager.LoadScene(5); //LEVEL3 (DONE)
//            SceneManager.LoadScene(6); //LEVEL4 (DONE)
//            SceneManager.LoadScene(7); //LEVEL5 (DONE)
//            SceneManager.LoadScene(8); //LEVEL6 (DONE)
//            SceneManager.LoadScene(9); //LEVEL7 (DONE)
//            SceneManager.LoadScene(10); //LEVEL8 (DONE)
//            SceneManager.LoadScene(11); //LEVEL9 (DONE)
//            SceneManager.LoadScene(12); //LEVEL10 (DONE)
            playerHasScored = false;
        }
    }

    void DestroyUIOnMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
            Destroy(this.gameObject);
            Destroy(playerUI);
        }
    }

    void GameOverUI()
    {
        if (playerDead)
        {
            Debug.Log($"playerDead = {playerDead}");
            SceneManager.LoadScene(13);
            playerDead = false;
            Debug.Log($"playerDead back to: {playerDead}");
        }

/*        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
            Destroy(playerUI);
        }*/
    }
}
