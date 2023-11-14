using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockLogic : MonoBehaviour
{
    public float previousTime;
    public float fallTime = 0.8f;
    public bool isGameOver = false;

    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];


    public SpawnManager spawnManager;
    public GameManager gameManager;
    public MenuFunctions menuFunctions;
    // Start is called before the first frame update
    void Start()
    {
        menuFunctions = FindObjectOfType<MenuFunctions>();
        spawnManager = FindObjectOfType<SpawnManager>();
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!isValid())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!isValid())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            if (!isValid())
            {
                transform.Rotate(0, 0, -90);
            }
        }
        
        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!isValid())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                this.enabled   = false;
                if (!isGameOver)
                {
                    spawnManager.SpawnBlock();
                }
            }
            previousTime = Time.time;
        }

    }

    void CheckLines()
    {
        for (int y = height-1; y >= 0;y--)
        {
            if (HasLine(y))
            {
                DeleteLine(y);
                RowLine(y);
                gameManager.AddScore(20);
            }
        }
    }

    bool HasLine(int y)
    {
        for( int j = 0; j<width;j++)
        {
            if (grid[j,y] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int y)
    {
        for (int j=0; j<width;j++)
        {
            Destroy(grid[j,y].gameObject);
            grid[j,y] = null;
        }
    }

    void RowLine(int y)
    {
        for (int i = y; i < height;i++)
        {
            for (int j = 0;j<width;j++)
            {
                if (grid[j,i] != null)
                {
                    grid[j,i-1] = grid[j,i];
                    grid[j,i] = null;
                    grid[j,i-1].transform.position -= new Vector3(0,1,0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundY] = children;

            if (roundY > 10)
            {
                isGameOver = true;
                GameOver();
                return;
            }
        }
    }
    bool isValid()
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            if (roundX < 0 || roundX >= width || roundY < 0 || roundY >= height)
            {
                return false;
            }

            if (grid[roundX,roundY] != null)
            {
                return false;
            }

        }
        return true;
    }

    public void GameOver()
    {
       
        spawnManager.gameOverText.text = "Game Over... Its Finished " + gameManager.GetScore().ToString();
        spawnManager.gameOverUI.gameObject.SetActive(true);
        
    }

    
}
