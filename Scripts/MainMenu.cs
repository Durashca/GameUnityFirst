using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play(int index)
    {
        Debug.Log("������� �� ����� � ��������: " + index);
        SceneManager.LoadScene(index);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
