using UnityEngine;

public class DiamondBehavior : MonoBehaviour
{
    GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Invoke("Die", Random.Range(3f, 7f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Die();
            gameController.points++;
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        gameController.diamondCount--;
    }
}
