using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace Center
{
    class InputBox
    {
        public System.Security.SecureString ShowPassword(string title, string DefaultText)
        {
            Window input = new Window()
            {
                Title = title,
                ResizeMode = ResizeMode.NoResize,
                ShowInTaskbar = false,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                WindowStyle = WindowStyle.ToolWindow,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            StackPanel stack = new StackPanel() { Margin = new Thickness(10) };
            WrapPanel wrap = new WrapPanel() { FlowDirection = FlowDirection.RightToLeft };
            Button Cancel = new Button() { Content = "取消" };
            Button OK = new Button() { Content = "确定" };
            wrap.Children.Add(OK);
            wrap.Children.Add(new Label());
            wrap.Children.Add(Cancel);
            for (int i = 0; i < 5; i++)
            {
                wrap.Children.Add(new Label());
            }
            PasswordBox In = new PasswordBox()
            {
                Password = DefaultText
            };
            stack.Children.Add(new Label());
            stack.Children.Add(In);
            stack.Children.Add(new Label());
            stack.Children.Add(wrap);
            stack.Children.Add(new Label());
            input.Content = stack;
            bool IsValue = false;
            Cancel.Click += (q, x) =>
            {
                IsValue = false;
                input.Close();
            };
            OK.Click += (d, k) =>
            {
                IsValue = true;
                input.Close();
            };
            input.KeyDown += (l, x) =>
              {
                  if (x.Key == System.Windows.Input.Key.Enter)
                  {
                      ButtonAutomationPeer peer = new ButtonAutomationPeer(OK);
                      IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                      invokeProv.Invoke();
                  }
                  if (x.Key == System.Windows.Input.Key.Escape)
                  {
                      ButtonAutomationPeer peer = new ButtonAutomationPeer(Cancel);
                      IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                      invokeProv.Invoke();
                  }
              };
            input.ShowDialog();
            if (IsValue)
            {
                return In.SecurePassword;
            }
            else
            {
                return null;
            }
        }

        public string Show(string title, string DefaultText)
        {
            Window input = new Window()
            {
                Title = title,
                ResizeMode = ResizeMode.NoResize,
                ShowInTaskbar = false,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                WindowStyle = WindowStyle.ToolWindow,
                SizeToContent = SizeToContent.WidthAndHeight
            };
            StackPanel stack = new StackPanel() { Margin = new Thickness(10) };
            WrapPanel wrap = new WrapPanel() { FlowDirection = FlowDirection.RightToLeft };
            Button Cancel = new Button() { Content = "取消" };
            Button OK = new Button() { Content = "确定" };
            wrap.Children.Add(OK);
            wrap.Children.Add(new Label());
            wrap.Children.Add(Cancel);
            for (int i = 0; i < 5; i++)
            {
                wrap.Children.Add(new Label());
            }
            TextBox In = new TextBox()
            {
                Text = DefaultText
            };
            In.SelectAll();
            stack.Children.Add(new Label());
            stack.Children.Add(In);
            stack.Children.Add(new Label());
            stack.Children.Add(wrap);
            stack.Children.Add(new Label());
            input.Content = stack;
            bool IsValue = false;
            Cancel.Click += (q, x) =>
            {
                IsValue = false;
                input.Close();
            };
            OK.Click += (d, k) =>
            {
                IsValue = true;
                input.Close();
            };
            input.KeyDown += (l, x) =>
            {
                if (x.Key == System.Windows.Input.Key.Enter)
                {
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(OK);
                    IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    invokeProv.Invoke();
                }
                if (x.Key == System.Windows.Input.Key.Escape)
                {
                    ButtonAutomationPeer peer = new ButtonAutomationPeer(Cancel);
                    IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                    invokeProv.Invoke();
                }
            };
            input.ShowDialog();
            if (IsValue)
            {
                return In.Text;
            }
            else
            {
                return null;
            }
        }
    }
}
