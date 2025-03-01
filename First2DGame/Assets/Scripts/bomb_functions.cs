using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bomb_functions : MonoBehaviour
{   
    public int bombDamage = 1;
    public int bombPoints = 5;
    public GameObject explosionEffectPrefab;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy bomb if it falls below the game camera view
        Vector3 bottomWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        float buffer = 1f; // Extra buffer below the screen
        if (transform.position.y < bottomWorld.y - buffer)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

 
        if (other.gameObject.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            Debug.Log("Bomb touched by Player!");

            player_dead playerScript = other.GetComponent<player_dead>();

            if (playerScript != null)
            {
                // Subtract the bomb damage from the player's lives
                playerScript.lives -= bombDamage;
                Debug.Log("Player hit by bomb. Lives remaining: " + playerScript.lives);
                if (playerScript.livesUI != null)
                {
                    playerScript.livesUI.UpdateLives(playerScript.lives);
                }
                if (playerScript.lives <= 0)
                {
                    // Optionally, call any death logic here before destroying the player
                    Destroy(other.gameObject);
                    if (playerScript.gameOverManager != null)
                    {
                        playerScript.gameOverManager.ShowGameOver();
                    }
                }
            }

            score_manager.instance.removePoints(bombPoints); // Add score
            StartCoroutine(DespawnWithEffects()); // Play effect & despawn
        }
    }

    IEnumerator DespawnWithEffects()
    {
        if (explosionEffectPrefab)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
