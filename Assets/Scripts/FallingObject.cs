using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private GameObject asteroide1;
    [SerializeField] private GameObject asteroide2;
    [SerializeField] private GameObject spaceship;

    static public List<GameObject> asteroides1 = new List<GameObject>();
    static public List<GameObject> asteroides2 = new List<GameObject>();
    static public List<GameObject> spaceships = new List<GameObject>();

    [SerializeField] private float fallingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Падение астероидов
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y -(1* Time.deltaTime * fallingSpeed),0);
    }
}
