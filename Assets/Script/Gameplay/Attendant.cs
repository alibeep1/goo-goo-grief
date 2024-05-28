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
    [SerializeField] int stops_count = 3;
    [SerializeField] GameOverScript gameOver;

    private Animator animator;

    private void Start()
    {
        // Start spawning enemies
        animator = GetComponent<Animator>();
        StartCoroutine(SpawnEnemies());
        animator.SetBool("isWalking", true);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Move enemy
            StartCoroutine(MoveEnemy(enemy, stops_count));

            // Wait for spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator MoveEnemy(GameObject enemy, int k)
    {
        int stopCounter = 0;
        while (enemy.transform.position.y > despawnY)
        {
            // Move enemy along the Y-axis in the opposite direction (downwards)
            enemy.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // Randomly stop the enemy k times during its movement
            if (stopCounter < k && UnityEngine.Random.value < 0.3f) // Adjust the probability as needed
            {
                stopCounter++;
                yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3)); // Adjust the range as needed
            }

            yield return null;
        }

        // Destroy enemy when it reaches despawnY
        Destroy(enemy);
    }


    //IEnumerator MoveEnemy(GameObject enemy)
    //{
    //    while (enemy.transform.position.y > despawnY)
    //    {
    //        // Move enemy along the Y-axis in the opposite direction (downwards)
    //        enemy.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

    //        yield return null;
    //    }

    //    // Destroy enemy when it reaches despawnY
    //    Destroy(enemy);
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided with babyyyyyyyy");
    //    // Check if the collided object is the baby prefab
    //    if (collision.gameObject == babyPrefab)
    //    {
    //        Debug.Log("ATTENDANT -> Enemy collided with the baby!");
    //        // End the game
    //        // GameOver();
    //        gameOver.Gameover();
    //    }
    //}

    //private void GameOver()
    //{
    //    // Implement game over logic here
    //    Debug.Log("Game Over");
    //    // For example, you can display a game over screen, stop the game, etc.
    //}
}