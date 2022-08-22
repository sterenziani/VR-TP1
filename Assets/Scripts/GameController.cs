using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool hasWon = false;
    private List<Can> cans = new List<Can>();
    private List<UnityEngine.UI.Text> screenTexts = new List<UnityEngine.UI.Text>();
    private ShootController ball;

    void Start()
    {
        hasWon = false;
        ball = GameObject.FindObjectOfType<ShootController>();
        foreach (Transform child in transform)
            cans.Add(child.gameObject.GetComponent<Can>());
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("ScreenText"))
            screenTexts.Add(go.GetComponent<UnityEngine.UI.Text>());
        changeScreenText("Knock the cans!");
    }

    void Update()
    {
        hasWon = true;
        foreach (Can c in cans)
        {
            if (c.isStanding)
                hasWon = false;
        }
        if(hasWon)
        {
            changeScreenText("YOU WIN!");
            ball.enabled = false;
            Invoke("NextLevel", 5f);
        }
    }

    private void changeScreenText(string text)
    {
        foreach (UnityEngine.UI.Text t in screenTexts)
            t.text = text;
    }

    private void NextLevel()
    {
        int nextLevel = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextLevel);
    }
}
