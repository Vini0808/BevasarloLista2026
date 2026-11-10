using System.Windows;
using System.Windows.Input;

namespace BevasarloLista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> groceryItems = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GroceryTextBox.Text))
            {
                groceryItems.Add(GroceryTextBox.Text);
                GroceryListBox.ItemsSource = null;
                GroceryListBox.ItemsSource = groceryItems;
                GroceryTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a grocery item.");
            }
        }

        private void KeyDownEnter(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                AddButton_Click(sender, e);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            groceryItems.Remove(GroceryListBox.SelectedItem as string);
            GroceryListBox.ItemsSource = null;
            GroceryListBox.ItemsSource = groceryItems;
        }

        private void DeleteEveryButton_Click(object sender, RoutedEventArgs e)
        {
            groceryItems.Clear();
            GroceryListBox.ItemsSource = null;
        }
    }
}