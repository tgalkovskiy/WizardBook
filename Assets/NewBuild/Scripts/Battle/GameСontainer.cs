
using UnityEngine;
using UnityEngine.UI;

public class GameСontainer : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject fireEnemy;
    public Transform posToSpawnEnemy;
    public Text textPrefab;
    public RectTransform canvas;
    public GameObject potionPartical;
    public GameObject weaknessFogPartical;
    public GameObject fastDamagePartical;
    public ParticleSystem arsonDamage;
    public ParticleSystem freezingDamage;
    public ParticleSystem entanglementPartical;
    public GameObject antiMagicFog;

    public (GameObject, GameObject) InitGameObjectToScene(GameConfig playerConfig, EnemyConfig enemyConfig)
    {
        var enemy = Instantiate(enemyConfig.SelectEnemyPrefab(), posToSpawnEnemy);
        var player = Instantiate(playerPrefab);
        player.GetComponent<PlayerContainer>().SetWeapon(playerConfig.NumberSworld);
        return (player, enemy);
    }
}
