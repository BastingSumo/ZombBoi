using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject GetCurrentPlayerObject { get => CurrentPlayerObject; }

    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] Transform SpawnLocation;
    [SerializeField] float SpawnPlayerAfterSeconds = 1;
    [SerializeField] GameObject CurrentPlayerObject;
    public enum GameState
    {
        Initialising,
        MainMenu,
        Playing,
        Paused,
        Dead,
    }

    public static GameState CurrentGameState;

    public float DeathTimer;
    public float GameTimer;

    private void Awake()
    {
        CurrentGameState = GameState.Initialising;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        CurrentPlayerObject = Instantiate(PlayerPrefab, SpawnLocation.position, Quaternion.identity);
    }

    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Initialising:
                break;

            case GameState.MainMenu:
                break;

            case GameState.Playing:

                GameTimer += Time.deltaTime;
                break;

            case GameState.Paused:
                break;

            case GameState.Dead:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                CurrentGameState = GameState.Playing;
                break;

            default:
                break;
        }
    }
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(SpawnPlayerAfterSeconds);
        CurrentPlayerObject = Instantiate(PlayerPrefab, SpawnLocation.position, Quaternion.identity);
    }
}
