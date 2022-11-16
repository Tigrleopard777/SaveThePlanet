using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private GameObject asteroide1;
    [SerializeField] private GameObject asteroide2;
    [SerializeField] private GameObject spaceship;

    static public List<GameObject> asteroides1 = new List<GameObject>();
    static public List<GameObject> asteroides2 = new List<GameObject>();
    static public List<GameObject> spaceships = new List<GameObject>();
    static public bool gameRun = true;

    [SerializeField] private float spawmTime;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRun)
        {
            timer += Time.deltaTime;
            if (timer >= spawmTime)
            {
                int typeOfObject = Random.Range(1, 4);
                switch (typeOfObject)
                {
                    case (1):
                        asteroides1.Add(Instantiate(asteroide1, new Vector3(Random.Range(-(UI.worldWidthInUnits - asteroide1.transform.lossyScale.x), (UI.worldWidthInUnits - asteroide1.transform.lossyScale.x)), UI.worldHeightInUnits, 0), Quaternion.identity) as GameObject);
                        break;
                    case (2):
                        asteroides2.Add(Instantiate(asteroide2, new Vector3(Random.Range(-(UI.worldWidthInUnits - asteroide2.transform.lossyScale.x), (UI.worldWidthInUnits - asteroide2.transform.lossyScale.x)), UI.worldHeightInUnits, 0), Quaternion.identity) as GameObject);
                        break;
                    case (3):
                        spaceships.Add(Instantiate(spaceship, new Vector3(Random.Range(-(UI.worldWidthInUnits - spaceship.transform.lossyScale.x), (UI.worldWidthInUnits - spaceship.transform.lossyScale.x)), UI.worldHeightInUnits, 0), Quaternion.identity) as GameObject);
                        break;
                    default:
                        break;
                }
                timer = 0;
            }
        }
    }
}
