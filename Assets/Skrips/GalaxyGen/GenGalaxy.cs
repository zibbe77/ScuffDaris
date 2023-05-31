using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenGalaxy : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject lineHolder;
    LineRenderer lineRenderer;

    List<GameObject> StarList = new List<GameObject>();
    List<GameObject> StreamsList = new List<GameObject>();

    void Start()
    {
        lineRenderer = lineHolder.GetComponent<LineRenderer>();
    }

    public void GenGalaxyMe()
    {
        Galaxy Gax = new Galaxy(500, 10, 200);

        //star gen
        int name = 1;
        foreach (var star in Gax.Nodes)
        {
            GameObject starObj;
            starObj = Instantiate(starPrefab, new Vector3(star.Value.point.X, star.Value.point.Z, star.Value.point.Y), Quaternion.identity);
            starObj.name = (name).ToString();

            name++;
            StarList.Add(starObj);
        }

        //stream gen
        foreach (var stream in Gax.Streams)
        {
            GameObject streamObj;
            streamObj = Instantiate(lineHolder, new Vector3(stream.Value.root0.point.X, stream.Value.root0.point.Z, stream.Value.root0.point.Y), Quaternion.identity);

            Vector3[] linePos = new Vector3[2];
            linePos[0] = new Vector3(stream.Value.root0.point.X, stream.Value.root0.point.Z, stream.Value.root0.point.Y);
            linePos[1] = new Vector3(stream.Value.root1.point.X, stream.Value.root1.point.Z, stream.Value.root1.point.Y);

            lineRenderer.SetPositions(linePos);
            StreamsList.Add(streamObj);
        }
    }

    public void DelGalaxyGen()
    {
        foreach (var item in StarList)
        {
            Destroy(item);
        }
        foreach (var item in StreamsList)
        {
            Destroy(item);
        }
    }
}