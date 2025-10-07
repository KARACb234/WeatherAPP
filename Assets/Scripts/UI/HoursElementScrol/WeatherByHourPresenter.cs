using System;
using UnityEngine;

namespace UI.HoursElementScrol
{
    public class WeatherByHourPresenter
    {
        private WeatherByHourView _view;

        public WeatherByHourPresenter(WeatherByHourView view)
        {
            _view = view;
            _view.GetLeftButton.onClick.AddListener(LeftButtonClick);
            _view.GetRightButton.onClick.AddListener(RightButtonClick);
        }

        private void LeftButtonClick()
        {
            float position = _view.GetHorizontalNormalizedPosition() - 0.2f;
            _view.GoToScrol(position);
        }
        
        private void RightButtonClick()
        {
            float position = _view.GetHorizontalNormalizedPosition() + 0.2f;
            _view.GoToScrol(position);
        }

        public void Destroy()
        {
            _view.GetLeftButton.onClick.RemoveListener(LeftButtonClick);
            _view.GetRightButton.onClick.RemoveListener(RightButtonClick);
        }
    }
}