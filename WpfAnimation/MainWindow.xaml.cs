using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfAnimation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Duration _animationDuration = new
            Duration(TimeSpan.FromSeconds(1.0));

        public MainWindow()
        {
            InitializeComponent();
            ChangeContent(new ScreenOne(new TransitionControl(this)));
        }

        private DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler
            completedEventHandler)
        {
            var doubleAnimation = new DoubleAnimation(from, to,
                _animationDuration);
            if (completedEventHandler != null)
            {
                doubleAnimation.Completed += completedEventHandler;
            }
            return doubleAnimation;
        }

        private void SlideAnimation(UIElement newContent, UIElement oldContent, EventHandler
            completedEventHandler)
        {
            var leftStart = Canvas.GetLeft(oldContent);
            Canvas.SetLeft(newContent, leftStart - Width);
            TransitionContainer.Children.Add(newContent);
            if (double.IsNaN(leftStart))
            {
                leftStart = 0;
            }

            var outAnimation = CreateDoubleAnimation(leftStart,
                leftStart + Width, null);
            var inAnimation = CreateDoubleAnimation(leftStart - Width,
                leftStart, completedEventHandler);
            oldContent.BeginAnimation(Canvas.LeftProperty, outAnimation);
            newContent.BeginAnimation(Canvas.LeftProperty, inAnimation);
        }

        public void ChangeContent(UIElement newContent)
        {
            switch (TransitionContainer.Children.Count)
            {
                case 0:
                    TransitionContainer.Children.Add(newContent);
                    return;

                case 1:
                    TransitionContainer.IsHitTestVisible = false;
                    var oldContent = TransitionContainer.Children[0];

                    SlideAnimation(newContent, oldContent, (s, a) =>
                    {
                        TransitionContainer.IsHitTestVisible = true;
                        TransitionContainer.Children.Remove(oldContent);
                        (oldContent as IDisposable)?.Dispose();
                        oldContent = null;
                    });
                    break;
            }
        }
    }
}