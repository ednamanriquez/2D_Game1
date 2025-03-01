using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_dead : MonoBehaviour
{

    public int lives = 3;
    public LivesUI livesUI;
    public GameOverManager gameOverManager;

    private Object GetLivesUI()
    {
        return livesUI;
    }

    private void Start()
    {
        if (livesUI != null)
        {
            livesUI.UpdateLives(lives);
        }
        
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bomb_enemy"))
        {

            lives--;
            
            if (livesUI != null)
            {
                livesUI.UpdateLives(lives);
            }

            if (lives <= 0)
            {
                Destroy(this.gameObject);

            }

            score_manager.instance.removePoints();
        }

        if(collision.gameObject.CompareTag("power_up"))
        {
            Destroy(collision.gameObject);
            score_manager.instance.addPoints();

        }
    }
}
