using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ZoomWpfView
{
    public class ViewModel : ViewModelBase
    {
        private const double Tolerance = 0.0001;
        private const double Unity = 1.0;

        private double _scale = Unity;
        public double Scale
        {
            get => _scale;
            set => Set(ref _scale, value);
        }

        public double ScaleStep => 0.1;

        public double MinimumScale => 0.1;

        public double MaximumScale => 4.0;

        public ICommand ZoomInCommand => new RelayCommand(
            () => Scale += ScaleStep, () => MaximumScale - Scale > Tolerance);
        public ICommand ZoomOutCommand => new RelayCommand(
            () => Scale -= ScaleStep, () => Scale - MinimumScale > Tolerance);
        public ICommand ResetZoomCommand => new RelayCommand(
            () => Scale = Unity, () => Math.Abs(Scale - Unity) > Tolerance);
    }
}