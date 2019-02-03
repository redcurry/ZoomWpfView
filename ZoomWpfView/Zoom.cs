using System;

namespace ZoomWpfView
{
    public class Zoom
    {
        private const double Tolerance = 0.0001;

        public Zoom(double step, double min, double max)
        {
            Step = step;
            Minimum = min;
            Maximum = max;

            Value = 1.0;
        }

        public double Step { get; }

        public double Minimum { get; }

        public double Maximum { get; }

        public double Value { get; private set; }

        public void To(double value) => Value = value;

        public void In() => Value += Step;

        public void Out() => Value -= Step;

        public void Reset() => Value = 1.0;

        public bool CanZoomIn() => Value - Maximum < -Tolerance;

        public bool CanZoomOut() => Value - Minimum > Tolerance;

        public bool CanReset() => Math.Abs(Value - 1.0) > Tolerance;
    }
}