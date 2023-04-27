using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesLeft;

    private void OnEnable()
    {
        Weapon.onEnemyKilled += EnemyCount;
    }
    private void OnDisable()
    {
        Weapon.onEnemyKilled -= EnemyCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyCount();
    }

    public void EnemyCount()
    {
        int count = 0;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                count++;
            }
        }
        enemiesLeft.text = count.ToString();
    }
}
