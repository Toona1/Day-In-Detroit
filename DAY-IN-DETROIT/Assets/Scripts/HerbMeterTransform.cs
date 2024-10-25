using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbMeterTransform : MonoBehaviour
{
    public PlayerMovement meter;
    [SerializeField] float x, y, z;
    // PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        meter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(meter.herbMeter * 960, y, z);
    }
}
