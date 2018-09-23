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

namespace WpfCustomControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControl;assembly=WpfCustomControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:MyCustomControl1/>
    ///
    /// </summary>
    public class MyCustomControl1 : Control
    {
        static MyCustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl1), new FrameworkPropertyMetadata(typeof(MyCustomControl1)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //demo purpose only, check for previous instances and remove the handler first 
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null) 
            button.Click += Button_Click;
        }


        void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseClickEvent();
        }

        public static readonly RoutedEvent ClickEvent =
           EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
           typeof(RoutedEventHandler), typeof(MyCustomControl1));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        protected virtual void RaiseClickEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(MyCustomControl1.ClickEvent);            
            RaiseEvent(args);
        }

    }
}
