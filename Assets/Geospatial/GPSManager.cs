using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

// ����̽��� GPS������ ��ũ���� UI Text�� ����ش�.
// 1. Permission ����
// 2. GPS ������ Location ���� �ʱ�ȭ
// 3. GPS ������ UI Text�� ����ֱ�
// * 10���� �̻� �־����� ��� GPS ���� ������Ʈ
public class GPSManager : MonoBehaviour
{
    [SerializeField] TMP_Text logTxt;
    [SerializeField] TMP_Text latitudeTxt;
    [SerializeField] TMP_Text longtitudeTxt;
    float latitude;
    float longtitude;

    [Serializable]
    class PokemonGPS
    {
        public string name;
        public float latitude;
        public float longitude;
        public bool isCaptured;

        public PokemonGPS(string name, float latitude, float longitude, bool isCaptured)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.isCaptured = isCaptured;
        }
    }

    [SerializeField] List<PokemonGPS> pokemonInfo = new List<PokemonGPS>();

    void Start()
    {
        StartCoroutine(TurnOnGPS());
    }

    IEnumerator TurnOnGPS()
    {
        // 1. Permission ����
        if(!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // ��ġȮ�� ���� ��û
            Permission.RequestUserPermission(Permission.FineLocation);

            yield return new WaitForSeconds(3);

            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                logTxt.text = "��ġ ���� ������ ������ּ���. 3�� �Ŀ� ���ø����̼��� ����˴ϴ�.";

                Application.Quit();
            }
        }

        if(!Input.location.isEnabledByUser)
        {
            logTxt.text = "��ġ ���� ������ ������ּ���. 3�� �Ŀ� ���ø����̼��� ����˴ϴ�.";

            yield return new WaitForSeconds(3);

            Application.Quit();
        }
        else
        {
            logTxt.text = "GPS is allowed";
        }

        // 2. GPS ������ Location ���� �ʱ�ȭ
        // ����̽��� GPS ���� ����
        Input.location.Start();

        while(Input.location.status == LocationServiceStatus.Initializing)
        {
            logTxt.text = "GPS is Initializing";

            yield return new WaitForSeconds(1);
        }

        if(Input.location.status != LocationServiceStatus.Failed) 
        {
            logTxt.text = "GPS Initialization Failed";
        }

        // 3. GPS ������ UI Text�� ����ֱ�
        // Latitude: 37.51406
        // Longtitude: 127.0295
        while (true)
        {
            latitude = Input.location.lastData.latitude;
            longtitude = Input.location.lastData.longitude;
            latitudeTxt.text = "Latitude: " + latitude.ToString();
            longtitudeTxt.text = "Longtitude: " + longtitude.ToString();

            logTxt.text = "";

            foreach (var pokemon in pokemonInfo)
            {
                Vector2 from = new Vector2(latitude, longtitude);
                Vector2 to = new Vector2(pokemon.latitude, pokemon.longitude);

                float distance = CalculateDistance(from, to);

                logTxt.text += $"{pokemon.name}�� {distance}���� �ְ�, ��ȹ �Ǿ����ϱ�? {pokemon.isCaptured}\n";

                if (distance < 10)
                {
                    // StartBattle();
                }
            }

            yield return new WaitForSeconds(1);

            Input.location.Start();
        }
    }

    // GPS A���� GPS B ������ �Ÿ��� ���
    /*    37.513800, 127.021600(GPS A)
          37.513600, 127.020500(GPS B)
          0.0002(20m), 0.0011(110m)
          * 100000
          0.0002, 0.009 -> 20m, 110m   */

    float CalculateDistance(Vector2 from, Vector2 to)
    {
        float distance = 0;

        float a = (from.y - to.y);
        float b = (from.x - to.x);
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        distance = c * 100000;

        return distance;
    }


    private void OnApplicationQuit()
    {
        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }
}
