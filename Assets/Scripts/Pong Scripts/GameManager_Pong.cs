using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Pong : MonoBehaviour
{

    public Ball ball;
    public Text playerScoreText;
    public Text aiScoreText;
    public Paddle playerPaddle;
    public Paddle AiPaddle;

    private int _playerScore;

    private int _AiScore;

    public void PlayerScores()
    {
        _playerScore++;
        Debug.Log(_playerScore);

        this.playerScoreText.text = _playerScore.ToString();
        ResetRound();

    }    

    public void AiScores()
    {
        _AiScore++;
        Debug.Log(_AiScore);

        this.aiScoreText.text = _AiScore.ToString();
        ResetRound();
    }

    private void ResetRound()
    {
        this.playerPaddle.ResetPos();
        this.AiPaddle.ResetPos();
        this.ball.ResetPos();
        this.ball.AddStartingForce();
    }    
}
