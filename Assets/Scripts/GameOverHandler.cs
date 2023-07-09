using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;

    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private ScoreSystem scoreSystem;

    public void EndGame()
    {
        gameOverDisplay.SetActive(true);

        int finalScore = scoreSystem.EndTimer();
        scoreText.text = $"Your Score: {finalScore}";

        asteroidSpawner.enabled = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueButton()
    {
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false;
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        asteroidSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }

}
