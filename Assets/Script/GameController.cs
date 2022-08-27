using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{

    [Space(5)]
    [Header("Blade Control")]
    public GameObject blade;
    float randomSpawnTime = 5;

    [Space(5)]
    [Header("Diamond Control")]
    public GameObject diamond;
    int diamonMaxSpawned = 5; 
    public int diamondCount = 0;
    public int points = 0;

    [Space(5)]
    [Header("GUI Control")]
    public TMP_Text txtDiamondPoints;

    [Space(5)]
    [Header("Life Control")]
    int maxLife = 5;
    public int life = 5;
    public Image[] barBattery;

    private void Start()
    {
        //txtDiamondPoints = GetComponent<TextMeshPro>();
        InvokeRepeating("SpawnBlade", 0, randomSpawnTime);

        for(int i = 0; i < maxLife; i++)
        {
            barBattery[i].enabled = true;
        }
    }

    private void Update()
    {
        if (diamondCount < diamonMaxSpawned) SpawnDiamond();

        txtDiamondPoints.text = $"x{points}";

        //lifeControl();

        
    }

    void SpawnBlade()
    {
        float x = Random.Range(0, 2);
        float y = Random.Range(3.5f, -1.5f);
        
        Vector3 pos = new Vector3( x < 1 ? -11 : 11 , y, 0f);
        Instantiate(blade, pos, Quaternion.identity);

        randomSpawnTime = Random.Range(2, 7);
    }
    void SpawnDiamond()
    {

        Instantiate(diamond, new Vector2(Random.Range(-7f, 7), Random.Range(-2f, 4.5f)), Quaternion.identity);
        diamondCount++;

    }


    public void TakeDMG(int dmg)
    {
        barBattery[life - 1].enabled = false;
        life -= dmg;
    }
}


// Obj coletaveis = szadiart.itch.io/rocky-world-platformer-set
// Emotes = pipoya.itch.io/free-popup-emotes-pack