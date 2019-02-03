using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ZoomWpfView
{
    public class ViewModel : ViewModelBase
    {
        private readonly Zoom _zoom;

        public ViewModel()
        {
            _zoom = new Zoom(0.1, 0.1, 4.0);
        }

        public double Scale
        {
            get => _zoom.Value;
            set
            {
                _zoom.To(value);
                RaisePropertyChanged();
            }
        }

        public double ScaleStep => _zoom.Step;

        public double ScaleMinimum => _zoom.Minimum;

        public double ScaleMaximum => _zoom.Maximum;

        public ICommand ZoomInCommand => new RelayCommand(ZoomIn, CanZoomIn);

        public ICommand ZoomOutCommand => new RelayCommand(ZoomOut, CanZoomOut);

        public ICommand ResetZoomCommand => new RelayCommand(ResetZoom, CanResetZoom);

        private void ZoomIn()
        {
            _zoom.In();
            RaisePropertyChanged(nameof(Scale));
        }

        private bool CanZoomIn() => _zoom.CanZoomIn();

        private void ZoomOut()
        {
            _zoom.Out();
            RaisePropertyChanged(nameof(Scale));
        }

        public bool CanZoomOut() => _zoom.CanZoomOut();

        private void ResetZoom()
        {
            _zoom.Reset();
            RaisePropertyChanged(nameof(Scale));
        }

        public bool CanResetZoom() => _zoom.CanReset();
    }
}