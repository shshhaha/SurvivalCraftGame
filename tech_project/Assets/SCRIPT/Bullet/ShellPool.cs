using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPool : MonoBehaviour
{
    public static ShellPool sharedInstance;
    public GameObject shellPrefab;
    public int poolSize = 5;
    private float returnTime = 5f;
    private Queue<GameObject> shellPool;

    void Awake()
    {
        sharedInstance = this;
        shellPool = new Queue<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject shell = Instantiate(shellPrefab);
            shell.SetActive(false);
            shellPool.Enqueue(shell);
        }
    }

    public GameObject GetShell()
    {
        GameObject shell;
        if (shellPool.Count > 0)
        {
            shell = shellPool.Dequeue();
        }
        else
        {
            shell = Instantiate(shellPrefab);
            shellPool.Enqueue(shell);
        }

        shell.SetActive(true);
        StartCoroutine(ReturnShellAfterSeconds(shell, returnTime));
        return shell;
    }

    public void ReturnShell(GameObject shell)
    {
        shell.SetActive(false);
        shell.GetComponent<Shell>().ResetCollisionCount();
        shellPool.Enqueue(shell);
    }

    IEnumerator ReturnShellAfterSeconds(GameObject shell, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (shell.activeInHierarchy)
        {
            ReturnShell(shell);
        }
    }
}