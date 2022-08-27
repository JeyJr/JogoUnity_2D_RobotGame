using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [Space(5)]
    [Header("Blade Control")]
    public GameObject blade;
    float randomSpawnTime = 5;

    [Space(5)]
    [Header("Diamond Control")]
    public GameObject diamond;
    public int diamonMaxSpawned = 5; 
    public int diamondCount = 0;

    [Space(5)]
    [Header("Points Control")]
    public int points = 0;
    public int maxPoints;
    public TMP_Text txtMaxPoints;

    [Space(5)]
    [Header("Life Control")]
    public int maxLife = 5;
    public int life = 5;
    public Image[] barBattery;

    [Space(5)]
    [Header("GUI Control")]
    public TMP_Text txtDiamondPoints;
    public GameObject startPanel;
    public Button play;

    private void Start()
    {
        StartGame(true, 0);

        for (int i = 0; i < maxLife; i++)
        {
            barBattery[i].enabled = true;
        }

        InvokeRepeating("SpawnBlade", 0, randomSpawnTime);

    }
    void StartGame(bool active, float timeScale)
    {
        startPanel.SetActive(active);
        maxPoints = PlayerPrefs.GetInt("MaxPoints");
        txtMaxPoints.text = $"Recorde: <color=red>{maxPoints}</color>";

        Time.timeScale = timeScale;
    }
    public void PlayGame()
    {
        StartGame(false, 1);
    }
    private void Update()
    {
        if (diamondCount < diamonMaxSpawned) SpawnDiamond();
        txtDiamondPoints.text = $"x{points}";
        if (life <= 0)
        {
            if (points > maxPoints)
            {
                PlayerPrefs.SetInt("MaxPoints", maxPoints);
            }
            SceneManager.LoadScene(0);
        }
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
    public void ResetPoints()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}


// Obj coletaveis = szadiart.itch.io/rocky-world-platformer-set
// Emotes = pipoya.itch.io/free-popup-emotes-pack
