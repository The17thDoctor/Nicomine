using UnityEngine;

public enum ScoreValue
{
    VILLAGER_HEALED = 500,
    GEYSER_PLUGGED = 1000,
    ANTIDOTE_MINED = 100,
    CORK_MINE = 200
}

public class GameManager : MonoBehaviour
{
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int value)
    {
        _score += (int)(value / Mathf.Log10(Time.timeSinceLevelLoad + 10));
    }

    public void AddToScore(ScoreValue value)
    {
        _score += (int)value;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
