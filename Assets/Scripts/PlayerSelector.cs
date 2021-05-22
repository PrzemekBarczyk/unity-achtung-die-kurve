using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    bool isSet;
    [SerializeField] Toggle toggle;
    [SerializeField] Text playerNameText;

    [SerializeField] GameObject leftKeyInfo;
    [SerializeField] Text leftKeyText;
    [SerializeField] GameObject rightKeyInfo;
    [SerializeField] Text rightKeyText;

    string playerName;
    KeyCode leftKey = KeyCode.None;
    KeyCode rightKey = KeyCode.None;

	void Start()
	{
        leftKeyInfo.SetActive(false);
        leftKeyText.gameObject.SetActive(false);
        rightKeyInfo.SetActive(false);
        rightKeyText.gameObject.SetActive(false);
	}

    public void ChoosePlayer()
	{
        if (toggle.isOn)
		{
            isSet = false;
            playerName = playerNameText.text;
            leftKeyInfo.SetActive(true);
            leftKeyText.gameObject.SetActive(false);
            StartCoroutine(ChooseLeftKey());
        }
        else if (!isSet)
		{
            leftKeyInfo.SetActive(false);
            rightKeyInfo.SetActive(false);
            leftKeyText.gameObject.SetActive(false);
            rightKeyText.gameObject.SetActive(false);
            RemovePlayerData();
		}
    }

    IEnumerator ChooseLeftKey()
	{
        leftKey = GetKeyDown();
        while (leftKey == KeyCode.None || leftKey == KeyCode.Mouse0 || !toggle.isOn)
		{
            yield return null;
            leftKey = GetKeyDown();
        }

        leftKeyInfo.SetActive(false);
        leftKeyText.text = leftKey.ToString();
        leftKeyText.gameObject.SetActive(true);
        rightKeyInfo.SetActive(true);
        rightKeyText.gameObject.SetActive(false);
        
        StartCoroutine(ChooseRightKey());
    }

    IEnumerator ChooseRightKey()
	{
        yield return null;

        rightKey = GetKeyDown();
        while (rightKey == KeyCode.None || rightKey == KeyCode.Mouse0 || !toggle.isOn)
		{
            yield return null;
            rightKey = GetKeyDown();
        }

        rightKeyInfo.SetActive(false);
        rightKeyText.text = rightKey.ToString();
        rightKeyText.gameObject.SetActive(true);

        SavePlayerData();
    }

    void SavePlayerData()
	{
        PlayerData player = GameManager.GetPlayer(playerName);
        if (player != null)
		{
            player.IsBot = false;
            player.LeftKey = leftKey;
            player.RightKey = rightKey;
            isSet = true;
		}
	}

    void RemovePlayerData()
	{
        PlayerData player = GameManager.GetPlayer(playerName);
        if (player != null)
        {
            player.IsBot = true;
            player.LeftKey = KeyCode.None;
            player.RightKey = KeyCode.None;
        }
    }

    KeyCode GetKeyDown()
	{
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
		{
            if (Input.GetKeyDown(keyCode)) return keyCode;
		}
        return KeyCode.None;
	}
}
