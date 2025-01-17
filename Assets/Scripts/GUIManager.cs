using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GUIManager : MonoBehaviour
{
    private GroupBox reportGB;
    private Button restartButton;
    private LevelManager levelManager;
    private Label scoreLabel;
    private Label endLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        reportGB = root.Q<GroupBox>("report");
        restartButton = root.Q<Button>("Restart");
        scoreLabel = root.Q<Label>("ScoreLabel");
        endLabel = root.Q<Label>("EndLabel");
        

        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        
        restartButton.clicked += RestartButtonPressed;

    }

    // Update is called once per frame
    void Update()
    {
        float currentScore = levelManager.getScore();
        // Debug.Log("GUI TIME: " + currentScore);
        scoreLabel.text = "SCORE: " + currentScore.ToString("0");
        if (levelManager.gameEnd)
        {
            restartButton.visible = true;
            endLabel.visible = true;
        }
        else
        {
            restartButton.visible = false;
            endLabel.visible = false;
        }
    }

    private void RestartButtonPressed()
    {
        SceneManager.LoadScene("Scenes/Start");
    }
}
