using System.Windows;
using System.Windows.Media;

namespace ZoomWpfView
{
    public partial class MainWindow : Window
    {
        private readonly Zoom _zoom;

        public MainWindow()
        {
            InitializeComponent();

            _zoom = new Zoom(0.1, 0.1, 4.0);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateZoomViews();

            ZoomSlider.Minimum = _zoom.Minimum;
            ZoomSlider.Maximum = _zoom.Maximum;
            ZoomSlider.TickFrequency = _zoom.Step;
        }

        private void ZoomInButton_OnClick(object sender, RoutedEventArgs e)
        {
            _zoom.In();
            UpdateZoomViews();
        }

        private void ZoomOutButton_OnClick(object sender, RoutedEventArgs e)
        {
            _zoom.Out();
            UpdateZoomViews();
        }

        private void ResetZoomButton_OnClick(object sender, RoutedEventArgs e)
        {
            _zoom.Reset();
            UpdateZoomViews();
        }

        private void ZoomSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _zoom.To(ZoomSlider.Value);
            UpdateZoomViews();
        }

        private void UpdateZoomViews()
        {
            MainView.LayoutTransform = new ScaleTransform(_zoom.Value, _zoom.Value);

            ZoomInButton.IsEnabled = _zoom.CanZoomIn();
            ZoomOutButton.IsEnabled = _zoom.CanZoomOut();
            ResetZoomButton.IsEnabled = _zoom.CanReset();

            ZoomTextBlock.Text = $"{_zoom.Value * 100}%";
            ZoomSlider.Value = _zoom.Value;
        }
    }
}
