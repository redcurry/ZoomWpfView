using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ZoomWpfView
{
public class ViewModel : ViewModelBase
{
    private const decimal Unity = 1;

    private decimal _scale = Unity;
    public decimal Scale
    {
        get => _scale;
        set => Set(ref _scale, value);
    }

    public decimal ScaleStep => 0.1m;

    public decimal MinimumScale => 0.1m;

    public decimal MaximumScale => 4.0m;

    public ICommand ZoomInCommand => new RelayCommand(
        () => Scale += ScaleStep, () => Scale < MaximumScale);

    public ICommand ZoomOutCommand => new RelayCommand(
        () => Scale -= ScaleStep, () => Scale > MinimumScale);

    public ICommand ResetZoomCommand => new RelayCommand(
        () => Scale = Unity, () => Scale != Unity);
}
}