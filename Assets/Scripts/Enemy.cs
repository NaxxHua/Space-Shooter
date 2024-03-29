using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private float _speed = 1.5f;
  [SerializeField]
  private GameObject _laserPrefab;

  private Player _player1;
  private Player _player2;

  private Animator _anim;

  private AudioSource _audioSource;

  private float _fireRate = 3.0f;
  private float _canFire = -1;


  // Start is called before the first frame update
  void Start()
  {
    _player1 = GameObject.Find("Player_1").GetComponent<Player>();

    if (GameObject.Find("Player_2") != null)
    {
      _player2 = GameObject.Find("Player_2").GetComponent<Player>();
    }

    _audioSource = GetComponent<AudioSource>();
    if (_player1 == null)
    {
      Debug.LogError("The Player is null");
    }

    _anim = GetComponent<Animator>();

    if (_anim == null)
    {
      Debug.LogError("The Animator is null");
    }
  }

  // Update is called once per frame
  void Update()
  {
    CalculateMovement();

    if (Time.time > _canFire)
    {
      _fireRate = Random.Range(3f, 7f);
      _canFire = Time.time + _fireRate;
      GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
      Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

      for (int i = 0; i < lasers.Length; i++)
      {
        lasers[i].AssignEnemyLaser();
      }
    }
  }

  void CalculateMovement()
  {
    transform.Translate(Vector3.down * _speed * Time.deltaTime);

    if (transform.position.y < -5f)
    {
      float randomX = Random.Range(-8f, 8f);
      transform.position = new Vector3(randomX, 7, 0);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {

    if (other.tag == "Player")
    {
      Player player = other.transform.GetComponent<Player>();
      if (player != null)
      {
        player.Damage();
      }

      _anim.SetTrigger("OnEnemyDeath");
      _speed = 0;
      _audioSource.Play();
      Destroy(this.gameObject, 2.8f);
    }

    if (other.tag == "Laser")
    {
      Destroy(other.gameObject);

      _anim.SetTrigger("OnEnemyDeath");
      _speed = 0;
      _audioSource.Play();

      Destroy(GetComponent<Collider2D>());
      Destroy(this.gameObject, 3f);

      if (_player1 != null)
      {
        _player1.AddScore(10);
      }

      if (_player2 != null)
      {
        _player2.AddScore(10);
      }
    }
  }
}
