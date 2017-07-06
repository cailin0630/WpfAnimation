using System;
using System.Windows.Controls;

namespace WpfAnimation
{
    /// <summary>
    /// TransitionControl.xaml 的交互逻辑
    /// </summary>
    public partial class TransitionControl : UserControl
    {
        public TransitionControl()
        {
            InitializeComponent();
        }

        public MainWindow ParentWindow { get; set; }
        public TransitionControl CurrentScreen { get; set; }

        public TransitionControl(MainWindow parent)
        {
            this.ParentWindow = parent;
        }

        public void ChangeScreen(TransitionControl screen)
        {
            this.CurrentScreen = screen ?? throw new ArgumentNullException("Unable to navigate to next screen. A null reference section occurred");
            this.ParentWindow.ChangeContent(screen);
        }
    }
}