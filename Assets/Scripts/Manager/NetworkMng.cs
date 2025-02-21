using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkMng : MonoBehaviourPunCallbacks
{
    [SerializeField]
    UnityEngine.UI.InputField inputfildId = null;
    [SerializeField]
    UnityEngine.UI.InputField inputfildPwd = null;

    [SerializeField]
    private GameObject uigame = null;

    public string nickname = "";

    private static NetworkMng _Instance;
    public static NetworkMng I
    {
        get
        {
            if (_Instance.Equals(null))
            {
                Debug.Log("Instance is null");
            }
            return _Instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _Instance = this;

        // 개발용 소스
        //PhotonNetwork.GameVersion = "1.0";      // 게임 버전
        //PhotonNetwork.ConnectUsingSettings();   // 서버 연결
    }

    /**
     * @brief 회원가입 창으로 이동
     */
    public void SignUp()
    {
        System.Diagnostics.Process.Start("https://google.com");
    }

    public void ConnectToServer()
    {
        PhotonNetwork.GameVersion = "1.0";      // 게임 버전
        PhotonNetwork.ConnectUsingSettings();   // 서버 연결
    }
    /**
     * @brief 웹통신으로 로그인
     */
    public void Login()
    {
        if(Application.internetReachability.Equals(NetworkReachability.NotReachable))
        {
            // 인터넷이 연결 안되어 있을떄
            // 로그인 실패 UI 만들어주세요
            Debug.Log("network disconnected");
        }
        else
        {
            // TODO 서버 상태보고 로그인 구현
            Debug.Log(inputfildId.text);
            Debug.Log(inputfildPwd.text);

            LoadingBar.LoadScene("InGame Scene");
        }
    }

    /**
     * @brief Master권한으로 서버 연결 callback 함수
     */
    public override void OnConnectedToMaster()
    {
        //Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom(); // 렌덤 room 들어가는곳
    }

    /**
     * @brief 랜덤 방 들어가기 실패 했을때 callback 함수
     * @param short returnCode 에러 코드
     * @param string message 에러 메시지
     */
    public override void OnJoinRandomFailed(short retrunCode, string message)
    {
        //Debug.Log("no room");
        PhotonNetwork.CreateRoom("myroom");     // 방 생성
    }

    /**
     * @brief 방 생성 되었을때 callback함수
     */
    public override void OnCreatedRoom()
    {
        //Debug.Log("Created room");
    }

    /**
     * @brief 방 들어간거 성공 했을때 callback 함수
     */
    public override void OnJoinedRoom()
    {
        StartCoroutine(this.CreatePlayer());
        //Debug.Log("Joined room");
    }

    /**
     * @brief player 생성
     */
    IEnumerator CreatePlayer()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(0, 2, 0), Quaternion.identity, 0);

        yield return null;
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
}
