using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attendant : MonoBehaviour
{
    // [SerializeField] public AttandantPrefabScript prefabScript;
    [SerializeField] public bool flag = false;
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] public GameObject babyPrefab;
    [SerializeField] public float spawnInterval = 30f; // Interval between enemy spawns
    [SerializeField] public float moveSpeed = 5f; // Speed at which enemies move
    [SerializeField] public float despawnY = -80f; // Y position at which enemies despawn

    private Animator animator;

    private void Start()
    {
        // Start spawning enemies
        animator = GetComponent<Animator>();
        StartCoroutine(SpawnEnemies());
        animator.SetBool("isWalking", true); // Always start walking
        // prefabScript = GetComponent<AttandantPrefabScript>();
        // Debug.Log("Flag value from prefab: " + prefabScript.FlightAttandantCollision);
    }

    // private void Update ()
    // {
    //     prefabScript = GetComponent<AttandantPrefabScript>();
    //     Debug.Log("Flag value from prefab: " + prefabScript.FlightAttandantCollision);
    // }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Move enemy
            StartCoroutine(MoveEnemy(enemy));

            // Wait for spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy.transform.position.y > despawnY)
        {
            // Move enemy along the Y-axis in the opposite direction (downwards)
            enemy.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            yield return null;
        }

        // Destroy enemy when it reaches despawnY
        Destroy(enemy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the baby prefab
        if (collision.gameObject == babyPrefab)
        {
            Debug.Log("Enemy collided with the baby!");
            // End the game
            GameOver();
        }
    }

    private void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over");
        // For example, you can display a game over screen, stop the game, etc.
    }
}