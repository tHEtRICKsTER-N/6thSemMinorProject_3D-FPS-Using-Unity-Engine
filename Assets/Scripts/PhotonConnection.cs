using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    #region VARIABLES
    public TMP_InputField usernameInputField;
    #endregion

    public void Login()
    {
        if (!string.IsNullOrEmpty(usernameInputField.text))
        {
            PhotonNetwork.LocalPlayer.NickName = usernameInputField.text;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Empty Name ! Please Enter The Username");
        }
    }

    public override void OnConnected()
    {
        Debug.Log("Connected !!");
    } 
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to Network !!");
    }
}
