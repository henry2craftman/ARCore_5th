using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// AR ī�޶� ���� ��, �� GPS����(GPSManager)�� ȸ������(CompassManager)�� �������� Pokemon�� �����Ѵ�.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<PokemonGPS> enemies = new List<PokemonGPS>();
    public List<PokemonGPS> Enemies { get { return enemies; } }
    GPSManager gPSManager;
    CompassManager compassManager;
    DatabaseManager databaseManager;

    void Awake()
    {
        /// AR ī�޶� ���� ��, �� GPS����(GPSManager)�� ȸ������(CompassManager)�� �������� Pokemon�� �����Ѵ�.
        gPSManager = FindAnyObjectByType<GPSManager>();
        compassManager = FindAnyObjectByType<CompassManager>();
        databaseManager = FindAnyObjectByType<DatabaseManager>();
    }

    private void Start()
    {
        StartCoroutine(CheckSensorStatus());
    }


    // CompassManager�� GPSManager�� ������ ��ٸ���.
    // ������ �޾�����, Pokemon�� �����Ѵ�. 
    IEnumerator CheckSensorStatus()
    {
        yield return new WaitUntil(() => gPSManager.IsDataReceived && compassManager.IsDataReceived);

        SpawnEnemy();
    }

    // �� GPS����(GPSManager)�� ȸ������(CompassManager)�� �������� Pokemon�� �����Ѵ�.
    private void SpawnEnemy()
    {
        foreach (var prefab in enemyPrefabs)
        {
            GameObject pokemon = Instantiate(prefab);

            PokemonGPS gPS = pokemon.GetComponent<Enemy>().Gps; // ���ϸ��� GPS����
            enemies.Add(gPS);

            Vector2 pokemonLocation = new Vector2(gPS.latitude, gPS.longtitude);
            Vector2 newPokemonLocation = gPSManager.RotationTransformation(pokemonLocation, compassManager.Angle);

            pokemon.transform.position = new Vector3(newPokemonLocation.x, 0, newPokemonLocation.y);

            gPSManager.logTxt.text += $"{pokemon.name}, Before({pokemonLocation.x}, {pokemonLocation.y}), After({newPokemonLocation.x},{newPokemonLocation.y})\n";
        }

        string json = SerializeToJson();
        databaseManager.SendData(json);
    }

    string SerializeToJson()
    {
        string json = "";

        //PokemonGPS gps1 = new PokemonGPS("mon1", 37.1f, 127.1f, false);
        //PokemonGPS gps2 = new PokemonGPS("mon2", 37.1f, 127.1f, false);
        //PokemonGPS gps3 = new PokemonGPS("mon3", 37.1f, 127.1f, false);
        //enemies.Add(gps1);
        //enemies.Add(gps2);
        //enemies.Add(gps3);

        foreach (var enemy in enemies)
        {
            json += JsonUtility.ToJson(enemy);
        }

        print(json);

        return json;
    }
}
