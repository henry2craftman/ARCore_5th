using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Firebase Realtime Database
// Pokemon GPS 데이터를 데이터베이스에 보내고, 데이터베이스에서 GPS 데이터를 요청해서 받는 역할
public class DatabaseManager : MonoBehaviour
{
    public void SendData(string json)
    {
        print("Data Sent");
    }

    void RequestData()
    {

    }

}
