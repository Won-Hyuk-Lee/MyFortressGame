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
        // ���� ���� �� �÷��̾� ������ ����
        isPlayerTurn = true;
    }

    void Update()
    {
        // ���� ���� Ÿ�̸� ������Ʈ
        turnTimer += Time.deltaTime;

        if (turnTimer >= turnTimeLimit)
        {
            // �� �ð� �ʰ� ó��
            EndTurn();
        }
    }

    // �÷��̾� �� ���� ó��
    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        turnTimer = 0.0f;
        // �ΰ����� �� ����
    }

    // �ΰ����� �� ���� ó��
    public void EndAITurn()
    {
        isPlayerTurn = true;
        turnTimer = 0.0f;
        // �÷��̾� �� ����
    }

    // �� ���� ó��
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

