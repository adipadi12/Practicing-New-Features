using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public DataManager CurrentState {get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        SetState(DataManager.Menu);
    }

    public void SetState(DataManager newState)
    {
        CurrentState = newState;

        Debug.Log("Game State changed to: " + newState.ToString());
    }
}
