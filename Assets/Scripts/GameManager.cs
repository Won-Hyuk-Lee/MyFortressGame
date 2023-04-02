using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }
    #endregion

    public float turnTimeLimit = 15.0f;
    private bool isPlayerTurn = true;
    private float turnTimer = 0.0f;

    void Start()
    {
        // 게임 시작 시 플레이어 턴으로 시작
        isPlayerTurn = true;
    }

    void Update()
    {
        // 현재 턴의 타이머 업데이트
        turnTimer += Time.deltaTime;

        if (turnTimer >= turnTimeLimit)
        {
            // 턴 시간 초과 처리
            EndTurn();
        }
    }

    // 플레이어 턴 종료 처리
    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        turnTimer = 0.0f;
        // 인공지능 턴 시작
    }

    // 인공지능 턴 종료 처리
    public void EndAITurn()
    {
        isPlayerTurn = true;
        turnTimer = 0.0f;
        // 플레이어 턴 시작
    }

    // 턴 종료 처리
    private void EndTurn()
    {
        if (isPlayerTurn)
        {
            EndPlayerTurn();
        }
        else
        {
            EndAITurn();
        }
    }
}

