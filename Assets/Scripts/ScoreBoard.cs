using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public GameObject board;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    [Header("Medal")]
    public Image medalImage;
    public List<Sprite> medalSprites;

    // Start is called before the first frame update
    void Start()
    {
        board.SetActive(false);
    }

    public void ShowScore(int score)
    {
        scoreText.text = $"score: {score}";

        if (PlayerPrefs.HasKey("best"))
        {
            int best = PlayerPrefs.GetInt("best");
            if (best > score)
            {
                bestText.text = $"Best: {best}";
            }
            else
            {
                bestText.text = $"Best: {score}";
                PlayerPrefs.SetInt("best", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            bestText.text = $"Best: {score}";
            PlayerPrefs.SetInt("best", score);
            PlayerPrefs.Save();
        }

        board.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
