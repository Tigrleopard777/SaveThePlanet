using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject aim;
    static private string asteroidTag = "Asteroid1";
    void Start()
    {
        Cursor.visible = false;
    }

    void TryToDestroy(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(position.x, position.y), Vector2.zero);
        if ((hit.collider != null) && hit.collider.CompareTag(asteroidTag))
        {
            UI.asteroides1.Remove(hit.collider.gameObject.transform.parent.gameObject);
            Destroy(hit.collider.gameObject.transform.parent.gameObject);
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
