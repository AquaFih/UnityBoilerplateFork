using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIController : MonoBehaviour
{
    public int lives;
    public int score;
    public float totalTime;
    public TextMeshProUGUI livesLabel;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI timeLabel;

    void Update()
    {
        totalTime += Time.deltaTime;

        livesLabel.text = "Lives: " + lives;
        scoreLabel.text = "Score: " + score;
        timeLabel.text = "Time: " + totalTime.ToString(format: "0.0") + "s";
    }

    public void Kill()
    {
        lives--;
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void Collect()
    {
        score++;
        if (score == 3)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
