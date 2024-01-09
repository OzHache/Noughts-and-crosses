using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneScoreText;
    [SerializeField] private TextMeshProUGUI playerTwoScoreText;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private GameObject playAgainButton;
    public void UpdatePlayerOneScore(int score)
    {
        playerOneScoreText.text = $"P1:{score}";
    }
    public void UpdatePlayerTwoScore(int score)
    {
        playerTwoScoreText.text = $"P2:{score}";
    }
    public void UpdateWinnerText(string text)
    {
        winnerText.text = text;
    }
    public void ShowWinnerText()
    {
        winnerText.gameObject.SetActive(true);
    }
    public void HideWinnerText()
    {
        winnerText.gameObject.SetActive(false);
    }
    public void ShowPlayAgainButton()
    {
        playAgainButton.SetActive(true);
    }
    public void HidePlayAgainButton()
    {
        playAgainButton.SetActive(false);
    }
    
}
