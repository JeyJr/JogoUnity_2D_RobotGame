using UnityEngine;

public class DiamondBehavior : MonoBehaviour
{
    GameController gameController;
    AudioControl audioControl;

    Animator anim;
    float randomTime;

    private void Awake()
    {
        randomTime = Random.Range(3f, 7f);

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        audioControl = gameController.GetComponent<AudioControl>();

        anim = gameObject.GetComponent<Animator>();
        Invoke("AnimDie", randomTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Die();
            gameController.points++;
            audioControl.PlayAudio(1);
        }
    }

    void AnimDie()
    {
        //no fim da animação a função DIE será executada
        anim.Play("dDisappearing");
    }

    void Die()
    {
        Destroy(this.gameObject);
        gameController.diamondCount--;
    }
}
