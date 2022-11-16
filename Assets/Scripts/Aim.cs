using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject aim;
    static private string asteroid1Tag = "Asteroid1";
    static private string asteroid2Tag = "Asteroid2";
    static private string spaceshipTag = "Spaceship";
    private int score = 0;
    
    void Start()
    {
        Cursor.visible = false;
    }

    void TryToDestroy(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(position.x, position.y), Vector2.zero);
        if ((hit.collider != null) && hit.collider.CompareTag(asteroid1Tag))
        {
            ObjectSpawn.asteroides1.Remove(hit.collider.gameObject.transform.parent.gameObject);
            Destroy(hit.collider.gameObject.transform.parent.gameObject);
            score += 1;
            UI.UpdatePoints(score);
        }
        if ((hit.collider != null) && hit.collider.CompareTag(asteroid2Tag))
        {
            ObjectSpawn.asteroides2.Remove(hit.collider.gameObject.transform.parent.gameObject);
            Destroy(hit.collider.gameObject.transform.parent.gameObject);
            score += 2;
            UI.UpdatePoints(score);
        }
        if ((hit.collider != null) && hit.collider.CompareTag(spaceshipTag))
        {
            ObjectSpawn.spaceships.Remove(hit.collider.gameObject.transform.parent.gameObject);
            Destroy(hit.collider.gameObject.transform.parent.gameObject);
            UI.DestroyHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimPozition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPozition.z = 0;
        aim.transform.position = aimPozition;
        if (Input.GetMouseButtonDown(0))
        {
            TryToDestroy(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }


}
