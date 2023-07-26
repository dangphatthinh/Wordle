using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI")]
    public GameObject invalidWord;
    public Button newWordBtn;
    public Button tryAgainBtn;
    public CanvasGroup gameOver;
    public CanvasGroup gameOverText;
    public CanvasGroup winText;
    public GameObject tutorial;

    public void PassTutorial()
    {
        tutorial.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        gameOver.alpha = 0;
        gameOverText.alpha = 0;
        winText.alpha = 0;
        tryAgainBtn.gameObject.SetActive(false);
        newWordBtn.gameObject.SetActive(false);       
    }
    public void GameOver() 
    {
        StartCoroutine(Fade(gameOver, 1f, 0.5f));
        StartCoroutine(Fade(gameOverText, 1f, 0.5f));
    }
    public void GameWin()
    {
        StartCoroutine(Fade(winText, 1f, 0.2f));
    }
    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;
        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
        tryAgainBtn.gameObject.SetActive(true);
        newWordBtn.gameObject.SetActive(true);
    }
}
