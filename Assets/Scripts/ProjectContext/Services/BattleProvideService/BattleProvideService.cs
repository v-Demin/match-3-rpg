using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleProvideService
{
    private string BATTLE_SCENE_NAME = "BattleScene";

    public BattleData Data { get; private set; }
    
    public void StartBattle(BattleData data)
    {
        Data = data;
        SceneManager.LoadScene(BATTLE_SCENE_NAME);
    }
}
