using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNumbers : MonoBehaviour {

    Transform message;
    Transform randRow;
    int zoneNumber;
    int zoneValue;
    Dictionary<int, Vector2[]> dict;

    void Awake()
    {
        message = GameObject.Find("Drawer").transform.Find("Message");

        Vector2[] uv0 = new Vector2[4];
        uv0[0] = new Vector2(0, 0);
        uv0[1] = new Vector2(0, 0.33f);
        uv0[2] = new Vector2(0.33f, 0.33f);
        uv0[3] = new Vector2(0.33f, 0);

        Vector2[] uv1 = new Vector2[4];
        uv1[0] = new Vector2(0, 0.66f);
        uv1[1] = new Vector2(0, 1);
        uv1[2] = new Vector2(0.33f, 1);
        uv1[3] = new Vector2(0.33f, 0.66f);

        Vector2[] uv2 = new Vector2[4];
        uv2[0] = new Vector2(0.33f, 0.66f);
        uv2[1] = new Vector2(0.33f, 1);
        uv2[2] = new Vector2(0.66f, 1);
        uv2[3] = new Vector2(0.66f, 0.66f);

        Vector2[] uv3 = new Vector2[4];
        uv3[0] = new Vector2(0.66f, 0.66f);
        uv3[1] = new Vector2(0.66f, 1);
        uv3[2] = new Vector2(1, 1);
        uv3[3] = new Vector2(1, 0.66f);

        Vector2[] uv4 = new Vector2[4];
        uv4[0] = new Vector2(0, 0.33f);
        uv4[1] = new Vector2(0, 0.66f);
        uv4[2] = new Vector2(0.33f, 0.66f);
        uv4[3] = new Vector2(0.33f, 0.33f);

        Vector2[] uv5 = new Vector2[4];
        uv5[0] = new Vector2(0.33f, 0.33f);
        uv5[1] = new Vector2(0.33f, 0.66f);
        uv5[2] = new Vector2(0.66f, 0.66f);
        uv5[3] = new Vector2(0.66f, 0.33f);

        Vector2[] uv6 = new Vector2[4];
        uv6[0] = new Vector2(0.66f, 0.33f);
        uv6[1] = new Vector2(0.66f, 0.66f);
        uv6[2] = new Vector2(1, 0.66f);
        uv6[3] = new Vector2(1, 0.33f);

        dict = new Dictionary<int, Vector2[]>();
        dict[0] = uv0;
        dict[1] = uv1;
        dict[2] = uv2;
        dict[3] = uv3;
        dict[4] = uv4;
        dict[5] = uv5;
        dict[6] = uv6;
    }

    void Start () 
	{
        randRow = message.GetChild(RandomQM.rand);
        foreach (Transform wallNumber in transform)
        {
            int name = int.Parse(wallNumber.name);
            zoneNumber = int.Parse(randRow.GetChild(name).name);
            zoneValue = UVOffset.zoneValues[zoneNumber];
            MeshFilter meshFilter = wallNumber.GetComponent<MeshFilter>();
            meshFilter.mesh.uv = dict[zoneValue];
        }
    }
}
