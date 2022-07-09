
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    public Text scoreText;
    public int Score = 0;
    public DontDestroy _dontdestroy;

    //public Text overallScore;

    void Awake()
    {
        Score = 0;
        EventManager.Instance.SubEvent("SendScore", SendScore);

    }
   /* private void Update()
    {
        _dontdestroy.Score = Score;
    }*/

    void SendScore(params object[] parameters)
    {
        Debug.Log(string.Join("SendScore", parameters));
        var points = (int)parameters[0];
        Score += points;
        scoreText.text = Score.ToString();
        EventManager.Instance.CallEvent("GiveMeScore");

    }

}
