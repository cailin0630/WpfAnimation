using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimation
{
    /// <summary>
    /// ScreenTwo.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenTwo : UserControl
    {
        private readonly TransitionControl _transCtrl;
        public ScreenTwo(TransitionControl transitionControl)
        {
           
            InitializeComponent();
            _transCtrl = transitionControl;
        }
        private void btnChangeContent_Click(object sender, RoutedEventArgs e)
        {
            var transCtrl = new TransitionControl(_transCtrl.ParentWindow);
            var screenOne = new ScreenOne(transCtrl);
            _transCtrl.ParentWindow.ChangeContent(screenOne);
        }
    }
}
