using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public AllGeyserScript geysers;
    public GameManager gameManager;
    public TMP_Text Timer;
    public int baseGameTime = 300;
    public int gameTime = 0;
    private float prevTime = 0;

    public void Start()
    {
        gameTime = baseGameTime;
    }
    public void FixedUpdate()
    {
        float calculatedTime = prevTime + Time.fixedDeltaTime;
        if (Mathf.Floor(calculatedTime) > Mathf.Floor(prevTime) && gameTime>0)
        {
            gameTime = gameTime - 1;
            setTimeText(gameTime);
            geysers.ChangeGeyserState(baseGameTime - gameTime);
            gameManager.ChangePeopleState(baseGameTime - gameTime);
            gameManager.RefreshScoreText();
        }

        prevTime = calculatedTime;
    }

    private void setTimeText(int gameTime){
        int seconds = gameTime % 60;
        int minutes = gameTime / 60;
        Timer.text = $"{minutes.ToString()}:{seconds.ToString()}";
    }
}