using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    public void SpawnBlock()
    {
        int randomBlock = Random.Range(0, blocks.Length);
        Instantiate(blocks[randomBlock], transform.position, blocks[randomBlock].transform.rotation);
    }
}
