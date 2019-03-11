using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQM : MonoBehaviour {

    static public int rand;
    Transform randRow;

	void Awake() 
	{
        Vector2[] uvQM = new Vector2[4];
        uvQM[0] = new Vector2(0.646f, 0.135f);
        uvQM[1] = new Vector2(0.697f, 0.135f);
        uvQM[2] = new Vector2(0.697f, 0.083f);
        uvQM[3] = new Vector2(0.646f, 0.083f);

        rand = Random.Range(0, 4);
        randRow = transform.GetChild(rand);
        foreach (Transform row in transform)
        {
            Renderer[] rends = row.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in rends)
            {
                rend.enabled = false;
            }
        }
        foreach (Transform square in randRow)
        {
            Renderer[] rends = randRow.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in rends)
            {
                rend.enabled = true;
            }
            MeshFilter meshFilter = square.GetComponent<MeshFilter>();
            meshFilter.mesh.uv = uvQM;
        }
    }
}
