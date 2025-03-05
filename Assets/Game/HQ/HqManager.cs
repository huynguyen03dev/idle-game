using UnityEngine;
using UnityUtils;

public class HqManager : Singleton<HqManager> {
    [SerializeField] private HqController hqContainer;

    public HqController GetHqController() {
        return hqContainer;
    }
}
