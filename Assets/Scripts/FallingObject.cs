using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private float fallingSpeed;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem explosionOnEarth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Падение объектов
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y -(1* Time.deltaTime * fallingSpeed),0);
        if(this.gameObject.transform.position.y < -UI.worldHeightInUnits)
        {
            switch(this.gameObject.tag)
            {
                case "Asteroid1":
                    ObjectSpawn.asteroides1.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    UI.DestroyHealth();
                    break;
                case "Asteroid2":
                    ObjectSpawn.asteroides2.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    UI.DestroyHealth();
                    break;
                case "Spaceship":
                    ObjectSpawn.spaceships.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    break;

            }

        }
    }

    private void OnDestroy()
    {
        if ((this.gameObject.transform.position.y > -UI.worldHeightInUnits))
        {
            Instantiate(explosion, this.gameObject.transform.position, Quaternion.identity);
        }
        if ((this.gameObject.tag != "Spaceship") && (this.gameObject.transform.position.y < -UI.worldHeightInUnits))
        {
            Instantiate(explosionOnEarth, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
