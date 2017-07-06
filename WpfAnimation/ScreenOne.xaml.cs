using System.Windows;
using System.Windows.Controls;

namespace WpfAnimation
{
    /// <summary>
    /// ScreenOne.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenOne : UserControl
    {
        private readonly TransitionControl _transitionControl;

        public ScreenOne(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
        }

        private void btnChangeContent_Click(object sender, RoutedEventArgs e)
        {
            _transitionControl.ParentWindow.ChangeContent(
                new ScreenTwo(new TransitionControl(_transitionControl.ParentWindow
                )));
        }
    }
}