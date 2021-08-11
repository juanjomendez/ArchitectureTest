using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{

    public Rigidbody2D rb;

    public BallController Ball;
    public PlayerController Player;

    public EdgeCollider2D pCollider;

    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GetReadyLabel;

    public uint Score = 0;
    public uint Lives = 3;

    uint Briks = 4;
    private bool _gameOver = false;

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        Reset();

        DrawBorder(pCollider);

    }


    public void DrawBorder(EdgeCollider2D collider)
    {
        LineRenderer lr = collider.gameObject.AddComponent<LineRenderer>();
        lr.startColor = Color.white;
        lr.endColor = Color.white;

        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        lr.material = whiteDiffuseMat;

        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.useWorldSpace = false;
        lr.positionCount = collider.points.Length + 1;

        for (int i = 0; i < collider.points.Length; i++)
        {
            lr.SetPosition(i, new Vector3(collider.points[i].x, collider.points[i].y));
        }
        lr.SetPosition(collider.points.Length, new Vector3(collider.points[0].x, collider.points[0].y));
    }


    public void Goal()
    {
        
        GetReadyLabel.enabled = true;

        var pos1 = Player.transform.position;
        pos1.x = 0f;
        Player.transform.position = pos1;

        Ball.transform.position = Vector3.zero;
        
        rb.velocity = Vector2.zero;

        ScoreLabel.text = Score.ToString();
        LivesLabel.text = Lives.ToString();

        StartCoroutine(StartGame());
    }

    private void Reset()
    {
        Score = 0;
        Lives = 3;
        Briks = 4;

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        GetReadyLabel.enabled = false;

        _gameOver = false;
        Ball.Kick();
    }

    private void Update()
    {
#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Lives = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Score = Briks;
        }
#endif

        if (_gameOver) 
            return;
        else
        {

            ScoreLabel.text = Score.ToString();
            LivesLabel.text = Lives.ToString();

            if (Score == Briks)
            {
                SceneManager.LoadScene("Win");
                _gameOver = true;
            }
            else if (Lives == 0)
            {
                int prevMaxScore = PlayerPrefs.GetInt("topscore");
                if (Score > prevMaxScore)
                    PlayerPrefs.SetInt("topscore", (int)Score);

                SceneManager.LoadScene("Lose");
                _gameOver = true;
            }
        }
    }
}