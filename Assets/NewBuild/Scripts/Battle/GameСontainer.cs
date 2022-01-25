
using UnityEngine;

public class GameСontainer : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject fireEnemy;
    public GameObject[] enemyPrefab;
    public TextMesh flyCounterPlayer;
    public TextMesh flyCounterEnemy;
    public Animator counterAnimator;
   
    public (GameObject, GameObject) InitGameObjectToScene(GameConfig playerConfig, EnemyConfig enemyConfig)
    {
        var enemy = Instantiate(enemyPrefab[enemyConfig.numberEnemy]);
        var player = Instantiate(playerPrefab);
        player.GetComponent<PlayerContainer>().SetWeapon(playerConfig.NumberSworld);
        return (player, enemy);
    }
}
