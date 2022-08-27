using UnityEngine;

public class BladesMovement : MonoBehaviour
{
    [Space(5)]
    [Header("Movement Control")]
    public bool moveToRight;
    public float speed = 3;

    private void Start()
    {
        //speed = Random.Range(1f, 4f);

        if (transform.position.x <= -10) moveToRight = true;
        else if (transform.position.x >= 10) moveToRight= false;

        Invoke("Die", 10); 
    }

    private void FixedUpdate()
    {
        if (moveToRight) transform.position += new Vector3(2 * speed, 0, 0) * Time.deltaTime;
        else transform.position -= new Vector3(2 * speed, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().TakeDMG(1);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
