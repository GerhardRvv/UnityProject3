using UnityEngine;

public class SpawnManager : MonoBehaviour {
    
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController _playerControllerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update() { }

    void SpawnObstacle() {
        if (!_playerControllerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
    
}