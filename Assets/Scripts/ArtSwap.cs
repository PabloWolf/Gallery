using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtSwap : MonoBehaviour
{
    int[] order;
    int count=0;
    public Texture[] im;
    public GameObject art;
    public string set = "Tr1";
    public string reset = "Tr2";
    bool ready = true;
    // Start is called before the first frame update
    void Start()
    {
        order = GetRandomSeq(im.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ready == true)
        {
            if (other.gameObject.name == set)
            {
                count = (count + 1) % (im.Length);

                art.GetComponent<Renderer>().material.mainTexture = im[order[count]];
                ready = false;
            }
        }
        else
        {
            if (other.gameObject.name == reset)
            {
                ready = true;
            }
        }

    }

    int[] GetRandomSeq(int n)
    {
        int[] r_arr = new int[n];
        int r = 0;

        for(int i = 1; i < n; i++)
        {
            
            bool u = false;
            while (u == false)
            {
                r = Random.Range(0, n);
                u = true;
                foreach (int j in r_arr)
                {
                    if (j == r)
                    {
                        u = false;
                    }
                }
            }
            r_arr[i] = r;

        }


        return r_arr;

    }

}
