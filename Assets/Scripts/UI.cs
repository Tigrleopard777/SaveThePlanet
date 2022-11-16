using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject asteroide1;
    [SerializeField] private GameObject asteroide2;
    [SerializeField] private GameObject spaceship;
    [SerializeField] private GameObject heart;

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Text scoreText;

    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    [SerializeField] private Image health4;
    [SerializeField] private Image health5;

    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text resultText;
    [SerializeField] private Button playAgainButton;

    static private List<Image> healths = new List<Image>();
    static private GameObject resultPanelStatic;
    static private Text resultTextStatic;
    static private Button playAgainButtonStatic;

    static private Text scoreTextStatic;
    private RectTransform rectBackgroundImage;
    static public List<GameObject> asteroides1 = new List<GameObject>();
    private float canvasWidth;
    private float canvasHeight;
    private Vector3 worldSize;
    static public float worldWidthInUnits;
    static public float worldHeightInUnits;
    private float worldWidthInPixels;
    private float worldHeightInPixels;
    private float heartWidhInPixels;
    private float heartHeightInPixels;
    private float heartWidhInUnits;
    private float heartHeightInUnits;
    void Start()
    {
        resultPanelStatic = resultPanel;
        resultTextStatic = resultText;
        playAgainButtonStatic = playAgainButton;
        resultPanelStatic.SetActive(false);
        scoreTextStatic = scoreText;
        healths.Add(health1);
        healths.Add(health2);
        healths.Add(health3);
        healths.Add(health4);
        healths.Add(health5);
        //canvasHeight = this.GetComponent<RectTransform>().rect.top;
        //canvasWidth = this.GetComponent<RectTransform>().rect.left;

        // worldSize = Camera.main.ScreenToWorldPoint(new Vector3(pixelWidth, pixelHeight, 0)); 
        //worldHeight = worldSize.y;
        //worldWidth = worldSize.x;

        //Bounds bounds = heart.GetComponent<MeshFilter>().sharedMesh.bounds;
        //heart.GetComponent<RectTransform>().rect.size.x

        Vector2 worldSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// правый верхний уголов в мировых координатах
        worldHeightInUnits = worldSize.y;
        worldWidthInUnits = worldSize.x;
        worldHeightInPixels = Camera.main.WorldToScreenPoint(new Vector3(worldSize.x, worldSize.y, 0)).y;
        worldWidthInPixels = Camera.main.WorldToScreenPoint(new Vector3(worldSize.x, worldSize.y, 0)).x;


        //Пиксели
        canvasWidth = this.GetComponent<RectTransform>().sizeDelta.x;
        canvasHeight = this.GetComponent<RectTransform>().sizeDelta.y;

        rectBackgroundImage = backgroundImage.GetComponent<RectTransform>();
        float imageWidth = rectBackgroundImage.rect.width;
        float imageHeight = rectBackgroundImage.rect.height;
        //float imageDeltaScale;
        //float heartDeltaScale;

/*
        heartWidhInPixels = heart.GetComponentInChildren<SpriteRenderer>().sprite.rect.size.x;
        heartHeightInPixels = heart.GetComponentInChildren<SpriteRenderer>().sprite.rect.size.y;
        heartWidhInUnits = Camera.main.ScreenToWorldPoint(new Vector3(heartWidhInPixels, heartHeightInPixels, 0)).x;
        heartHeightInUnits = Camera.main.ScreenToWorldPoint(new Vector3(heartWidhInPixels, heartHeightInPixels, 0)).y;

        if (worldHeightInPixels < worldWidthInPixels)
        {
            imageDeltaScale = canvasWidth / imageWidth;
            heartDeltaScale = (worldWidthInPixels / 15) / heartWidhInPixels;
        }
        else
        {
            imageDeltaScale = canvasHeight / imageHeight;
            heartDeltaScale = (worldWidthInPixels / 15) / heartWidhInPixels;
        } 
        
        heart.transform.localScale = new Vector3 (heartDeltaScale, heartDeltaScale, heartDeltaScale);
    */

        //heart.GetComponentInChildren<SpriteRenderer>().transform.
       //rectBackgroundImage.sizeDelta = new Vector2(imageWidth*imageDeltaScale, imageHeight*imageDeltaScale);
       // heart.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(heartDeltaScale, heartDeltaScale, heartDeltaScale);


        //Создание иконок жизней
        //Instantiate(heart, new Vector3(worldWidth - heart.transform.lossyScale.x, worldHeight - heart.transform.lossyScale.y, 0), Quaternion.identity);
        //Instantiate(heart, new Vector3(worldWidth - bounds.size.x, worldHeight - bounds.size.y, 0), Quaternion.identity);
       /*
        for (int i = 1; i <= 5; i++)
        {
            Instantiate(heart,
                new Vector3
                (Camera.main.ScreenToWorldPoint(new Vector3(worldWidthInPixels - (heartWidhInPixels * heartDeltaScale * i), worldHeightInPixels - (heartHeightInPixels * heartDeltaScale), 0)).x,
                Camera.main.ScreenToWorldPoint(new Vector3(worldWidthInPixels - (heartWidhInPixels * heartDeltaScale * i), worldHeightInPixels - (heartHeightInPixels * heartDeltaScale), 0)).y,
                0)
                , Quaternion.identity);
            Instantiate(heart,
                new Vector3
                (Camera.main.ScreenToWorldPoint(new Vector3(worldWidthInPixels, worldHeightInPixels - (heartHeightInPixels * heartDeltaScale), 0)).x,
                Camera.main.ScreenToWorldPoint(new Vector3(worldWidthInPixels - (heartWidhInPixels * heartDeltaScale * i), worldHeightInPixels, 0)).y,
                0)
                , Quaternion.identity);
        }
       */
        //Instantiate(heart, new Vector3(worldWidthInUnits - heartWidhInUnits, worldHeightUnits - heartHeightInUnits, 0), Quaternion.identity);
        //Instantiate(heart, new Vector3(worldWidthInUnits - heartV.x, worldHeightUnits - heartV.y, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
    }

    static public void UpdatePoints (int score)
    {
        scoreTextStatic.text = score.ToString();
    }

    static public void DestroyHealth()
    {
        if(healths.Count>0)
        {
            Destroy(healths[healths.Count - 1]);
            healths.RemoveAt(healths.Count-1);
        }
        if (healths.Count == 0)
        {
            ObjectSpawn.gameRun = false;
            resultPanelStatic.SetActive(true);
            resultTextStatic.text = "Your score: " + scoreTextStatic.text;
            for(int i = ObjectSpawn.asteroides1.Count-1; i>=0; i--)
            {
                Destroy(ObjectSpawn.asteroides1[i]);
                ObjectSpawn.asteroides1.RemoveAt(i);
            }
            for (int i = ObjectSpawn.asteroides2.Count - 1; i >= 0; i--)
            {
                Destroy(ObjectSpawn.asteroides2[i]);
                ObjectSpawn.asteroides2.RemoveAt(i);
            }
            for (int i = ObjectSpawn.spaceships.Count - 1; i >= 0; i--)
            {
                Destroy(ObjectSpawn.spaceships[i]);
                ObjectSpawn.spaceships.RemoveAt(i);
            }
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

