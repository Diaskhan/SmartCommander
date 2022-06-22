using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SmartCommander.Views
{
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
