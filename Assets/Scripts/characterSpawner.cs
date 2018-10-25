using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSpawner : MonoBehaviour {

    //enum enemyClass { cuerpo, distancia, tanque, agua};

    public struct Enemy
    {
        public enum enemmyClass { cuerpo, distancia, tanque, agua };
        public float life;
    };

    public Enemy enemy;
    public Enemy.enemmyClass tipoEnemigo;

    public Sprite cuerpoPrefab;
    public Sprite distanciaPrefab;
    public Sprite tanquePrefab;
    public Sprite aguaPrefab;
    public int enemyNumber;
    public float waveTime;

    private SpriteRenderer spriteR;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        enemy.life = 100.0f; 
    }

    void Update()
    {
        generateEnemy();
    }

    public void generateEnemy()
    {

        for (int i = 0; i < enemyNumber; i++)
        {
            Vector3 position = new Vector3(Random.Range(0, 7), 1.5f, Random.Range(0, 7));
            SpriteRenderer enemy = Instantiate(spriteR, position, Quaternion.identity);
        }
    }

    public void prefabSelector(Enemy.enemmyClass tipoEnemigo)
    {
        switch (tipoEnemigo)
        {
            case Enemy.enemmyClass.agua:
                spriteR.sprite = aguaPrefab;
                break;
            case Enemy.enemmyClass.cuerpo:
                spriteR.sprite = cuerpoPrefab;
                break;
            case Enemy.enemmyClass.distancia:
                spriteR.sprite = distanciaPrefab;
                break;
            case Enemy.enemmyClass.tanque:
                spriteR.sprite = tanquePrefab;
                break;
            default:
                break;
        }
    }

    public void aleatoryEnemyType()
    {
        int rnd = Random.Range(0, 100);
        if (rnd % 25 == 0)
        {
            tipoEnemigo = Enemy.enemmyClass.agua;
        }
        else if (rnd % 35 == 0)
        {
            tipoEnemigo = Enemy.enemmyClass.cuerpo;
        }
        else if (rnd % 50 == 0)
        {
            tipoEnemigo = Enemy.enemmyClass.distancia;
        }
        else
        {
            tipoEnemigo = Enemy.enemmyClass.tanque;
        }
    }
}
