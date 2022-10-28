using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform PlayerPrefab;
    [SerializeField] private Transform EnemyPrefab;
    private void Start()
    {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 character_Pos;
        Vector3 enemy_Pos;
        if (isPlayerTeam)
        {
            character_Pos = new Vector3(-5, -4);
            Instantiate(PlayerPrefab, character_Pos, Quaternion.identity);
        } else
        {
            enemy_Pos = new Vector3(+5, -4);
            Instantiate(EnemyPrefab, enemy_Pos, Quaternion.identity);
        }

    }
}
