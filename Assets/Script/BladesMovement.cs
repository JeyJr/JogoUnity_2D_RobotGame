using UnityEngine;

public class BladesMovement : MonoBehaviour
{
    public bool moveToRight;
    public float speed = 1;

    void Update()
    {
        if (transform.position.x <= -10) {
            moveToRight = true;
            speed = Random.Range(1, 5f);
        }
        else if (transform.position.x >= 10) moveToRight = false;



    }

    private void FixedUpdate()
    {
       MovingPlatform();
    }

    void MovingPlatform()
    {
        if (moveToRight) transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
        else transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }



}
