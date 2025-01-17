using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementApp.Views
{
    public class WybierzEventViewBase : UserControl
    {
        static WybierzEventViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WybierzEventViewBase), new FrameworkPropertyMetadata(typeof(WybierzEventViewBase)));
        }
    }
}
