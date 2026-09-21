
using UnityEngine;

namespace BubsyArchipelagoMod.Helpers;

public class APUpdater : MonoBehaviour
{
    public Action Action;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        Action?.Invoke();
    }
}