using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController _playerControllerScript;
    private float _leftBound = -15;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerControllerScript.gameOver) {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
