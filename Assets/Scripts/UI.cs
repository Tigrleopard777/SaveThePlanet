using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;



public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject asteroide1;
    [SerializeField] private GameObject asteroide2;
    [SerializeField] private GameObject spaceship;
    [SerializeField] private GameObject heart;
    [SerializeField] private float instantiateSped;
    
    [SerializeField] private Image backgroundImage;
    private RectTransform rectBackgroundImage;
    static public List<GameObject> asteroides1 = new List<GameObject>();
    private float canvasWidth;
    private float canvasHeight;
    private Vector3 worldSize;
    private float worldWidthInUnits;
    private float worldHeightInUnits;
    private float worldWidthInPixels;
    private float worldHeightInPixels;
    private float heartWidhInPixels;
    private float heartHeightInPixels;
    private float heartWidhInUnits;
    private float heartHeightInUnits;
    void Start()
    {
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
        float imageDeltaScale;
        float heartDeltaScale;


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

        //heart.transform.localScale = new Vector3 (heartDeltaScale, heartDeltaScale, heartDeltaScale);
        heart.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(heartDeltaScale, heartDeltaScale, heartDeltaScale);



        rectBackgroundImage.sizeDelta = new Vector2(imageWidth*imageDeltaScale, imageHeight*imageDeltaScale);



        //Создание иконок жизней
        //Instantiate(heart, new Vector3(worldWidth - heart.transform.lossyScale.x, worldHeight - heart.transform.lossyScale.y, 0), Quaternion.identity);
        //Instantiate(heart, new Vector3(worldWidth - bounds.size.x, worldHeight - bounds.size.y, 0), Quaternion.identity);
        for(int i = 1; i<=5; i++)
        {
            Instantiate(heart, 
                new Vector3
                (Camera.main.ScreenToWorldPoint( new Vector3(worldWidthInPixels - (heartWidhInPixels * heartDeltaScale * i), worldHeightInPixels - (heartHeightInPixels * heartDeltaScale), 0)).x,
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
        //Instantiate(heart, new Vector3(worldWidthInUnits - heartWidhInUnits, worldHeightUnits - heartHeightInUnits, 0), Quaternion.identity);
        //Instantiate(heart, new Vector3(worldWidthInUnits - heartV.x, worldHeightUnits - heartV.y, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            asteroides1.Add(Instantiate(asteroide1, new Vector3(Random.Range(-(worldWidthInUnits - asteroide1.transform.lossyScale.x), (worldWidthInUnits - asteroide1.transform.lossyScale.x)), worldHeightInUnits, 0), Quaternion.identity) as GameObject);
        }
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(asteroides1[0]);
            asteroides1.RemoveAt(0);
        }
    }
}
