using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;

    //On creation. Each waypoints position is added to the list of points
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i]=transform.GetChild(i);
        }
    }

}
