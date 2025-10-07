using UnityEngine;

namespace UI.HoursElement
{
    public class HourElementCreator : MonoBehaviour
    {
        [SerializeField]
        private HourElementUI _hourElementUI;

        public HourElementUI CreateHourElementUI(Transform hourElementTransform)
        {
            HourElementUI hourElementUI = Instantiate(_hourElementUI, hourElementTransform);
            return hourElementUI;
        }

        public void ClearHourElemetScrol(Transform contentTransform)
        {
            foreach (Transform child in contentTransform)
            {
                Destroy(child.gameObject);
            }
        }
        
    }
}