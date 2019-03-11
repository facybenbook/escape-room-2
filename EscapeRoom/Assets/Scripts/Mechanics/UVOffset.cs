using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UVOffset : MonoBehaviour
{
    static public Dictionary<int, int> zoneValues = new Dictionary<int, int>();
    static Dictionary<int, Vector2[]> UVs = new Dictionary<int, Vector2[]>();
    List<int> values;

    void Awake()
    {
        Vector2[] uv0 = new Vector2[4];
        uv0[0] = new Vector2(0.593f, 0.243f);
        uv0[1] = new Vector2(0.645f, 0.243f);
        uv0[2] = new Vector2(0.645f, 0.191f);
        uv0[3] = new Vector2(0.593f, 0.191f);

        Vector2[] uv1 = new Vector2[4];
        uv1[0] = new Vector2(0.54f, 0.243f);
        uv1[1] = new Vector2(0.592f, 0.243f);
        uv1[2] = new Vector2(0.592f, 0.191f);
        uv1[3] = new Vector2(0.54f, 0.191f);

        Vector2[] uv2 = new Vector2[4];
        uv2[0] = new Vector2(0.593f, 0.191f);
        uv2[1] = new Vector2(0.645f, 0.191f);
        uv2[2] = new Vector2(0.645f, 0.139f);
        uv2[3] = new Vector2(0.593f, 0.139f);

        Vector2[] uv3 = new Vector2[4];
        uv3[0] = new Vector2(0.646f, 0.243f);
        uv3[1] = new Vector2(0.698f, 0.243f);
        uv3[2] = new Vector2(0.698f, 0.191f);
        uv3[3] = new Vector2(0.646f, 0.191f);

        Vector2[] uv4 = new Vector2[4];
        uv4[0] = new Vector2(0.54f, 0.191f);
        uv4[1] = new Vector2(0.592f, 0.191f);
        uv4[2] = new Vector2(0.592f, 0.139f);
        uv4[3] = new Vector2(0.54f, 0.139f);

        Vector2[] uv5 = new Vector2[4];
        uv5[0] = new Vector2(0.646f, 0.191f);
        uv5[1] = new Vector2(0.698f, 0.191f);
        uv5[2] = new Vector2(0.698f, 0.139f);
        uv5[3] = new Vector2(0.646f, 0.139f);

        Vector2[] uv6 = new Vector2[4];
        uv6[0] = new Vector2(0.54f, 0.135f);
        uv6[1] = new Vector2(0.592f, 0.135f);
        uv6[2] = new Vector2(0.592f, 0.083f);
        uv6[3] = new Vector2(0.54f, 0.083f);

        Dictionary<int, Vector2[]> dict = new Dictionary<int, Vector2[]>();
        dict[0] = uv0;
        dict[1] = uv1;
        dict[2] = uv2;
        dict[3] = uv3;
        dict[4] = uv4;
        dict[5] = uv5;
        dict[6] = uv6;

        values = new List<int>();

        if (!Player.reloaded)
        {
            foreach (Transform child in transform) //for each row
            {
                int sum = 0; //row sum
                int assigned = 0; //row assigned
                int books = int.Parse(child.tag);
                foreach (Transform grandchild in child) //for each square
                {
                    int zone = int.Parse(grandchild.name); //zone name
                    MeshFilter meshFilter = grandchild.GetComponent<MeshFilter>();
                    int random = Random.Range(0, 7); //0-6
                    var value = dict[random];
                    sum += random;
                    if ((assigned == 0) && (random == 0))
                    {
                        assigned++;
                        int init = Random.Range(0, 2);
                        if (init == 0)
                        {
                            zoneValues[zone] = 0;
                            UVs[zone] = dict[0];
                        }
                        else
                        {
                            zoneValues[zone] = 1;
                            UVs[zone] = dict[1];
                        }
                        sum = sum + init;
                        meshFilter.mesh.uv = dict[init];
                    }
                    else if ((assigned == 1) && (random == 0))
                    {
                        meshFilter.mesh.uv = value;
                        assigned++;
                        zoneValues[zone] = random;
                        UVs[zone] = dict[random];
                    }
                    else if ((assigned < 2) && (sum < books) && (random != 0))
                    {
                        meshFilter.mesh.uv = value;
                        assigned++;
                        zoneValues[zone] = random;
                        UVs[zone] = dict[random];
                    }
                    else if ((assigned < 2) && (sum >= books) && (random != 0))
                    {
                        sum = sum - random + 1;
                        meshFilter.mesh.uv = uv1;
                        assigned++;
                        zoneValues[zone] = 1;
                        UVs[zone] = dict[1];
                    }
                    else if ((assigned == 2) && (sum < books))
                    {
                        int oldSum = (sum - random);
                        int difference = (books - oldSum);
                        meshFilter.mesh.uv = dict[difference];
                        zoneValues[zone] = difference;
                        UVs[zone] = dict[difference];
                        break;
                    }
                    else if ((assigned == 2) && (sum > books))
                    {
                        int oldSum = (sum - random);
                        int difference = (books - oldSum);
                        meshFilter.mesh.uv = dict[difference];
                        zoneValues[zone] = difference;
                        UVs[zone] = dict[difference];
                        break;
                    }
                    else if ((assigned == 2) && (sum == books))
                    {
                        meshFilter.mesh.uv = value;
                        zoneValues[zone] = random;
                        UVs[zone] = dict[random];
                        break;
                    }
                }
            }
        }

        else
        {
            foreach (Transform child in transform) //for each row
            {
                foreach (Transform grandchild in child) //for each square
                {
                    int zone = int.Parse(grandchild.name); //square name
                    MeshFilter meshFilter = grandchild.GetComponent<MeshFilter>();
                    meshFilter.mesh.uv = UVs[zone];
                }
            }
        }
        //GetValues();
    }

    public void GetValues()
    {
        foreach (KeyValuePair<int, int> zoneValue in zoneValues)
        {
            values.Add(zoneValue.Value);
        }
        //    //Debug.Log(values[0] + " " + values[1] + " " + values[2]);
        //    //Debug.Log(values[3] + " " + values[4] + " " + values[5]);
        //    //Debug.Log(values[6] + " " + values[7] + " " + values[8]);
        //    //Debug.Log(values[9] + " " + values[10] + " " + values[11]);
    }
}