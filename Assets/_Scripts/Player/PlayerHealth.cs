using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void Die()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.CurrentGameState = GameManager.GameState.Dead;
            HighScoreManager.Instance.ResetCurrentScore();
        }
    }
}
