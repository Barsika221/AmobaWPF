using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmobaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string recentPlayer = "X";
        private int playerX = 0;
        private int playerO = 0;
        private void GenerateBoard()
        {
            GameBoard.Children.Clear();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button();
                    button.Name = "Button" + row + col;
                    button.Width = 70;
                    button.Height = 70;
                    button.FontSize = 40;
                    button.Click += OnButtonClick;
                    GameBoard.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content == null)
            {
                button.Content = recentPlayer;
                if (recentPlayer == "X")
                {
                    recentPlayer = "O";
                }
                else
                {
                    recentPlayer = "X";
                }
            }
            CheckWinner();
            CheckDraw();
            RecentPlayerUpdate();
        }

        private void CheckDraw()
        {
            bool isDraw = true;
            foreach (Button button in GameBoard.Children)
            {
                if (button.Content == null)
                {
                    isDraw = false;
                    break;
                }
            }
            if (isDraw)
            {
                MessageBox.Show("Döntetlen!");
            }
        }

        private void RecentPlayerUpdate()
        {
            if (recentPlayer == "X")
            {
                PlayerTurn.Text = "Player 1 (X)";
            }
            else
            {
                PlayerTurn.Text = "Player 2 (O)";
            }
        }

        private void CheckWinner()
        {
            for (int row = 0; row < 3; row++)
            {
                if (CheckRow(row))
                {
                    return;
                }
            }
            for (int col = 0; col < 3; col++)
            {
                if (CheckColumn(col))
                {
                    return;
                }
            }
            if (CheckDiagonal())
            {
                return;
            }
        }

        private bool CheckDiagonal()
        {
            Button button1 = (Button)GameBoard.Children[0];
            Button button2 = (Button)GameBoard.Children[4];
            Button button3 = (Button)GameBoard.Children[8];
            if (button1.Content == button2.Content && button2.Content == button3.Content && button1.Content != null)
            {
                MessageBox.Show("A győztes: " + button1.Content);
                if (button1.Content.ToString() == "X")
                {
                    playerX++;
                    Player1Score.Text = playerX.ToString();
                }
                else
                {
                    playerO++;
                    Player2Score.Text = playerO.ToString();
                }
                return true;
            }
            button1 = (Button)GameBoard.Children[2];
            button3 = (Button)GameBoard.Children[6];
            if (button1.Content == button2.Content && button2.Content == button3.Content && button1.Content != null)
            {
                MessageBox.Show("A győztes: " + button1.Content);
                if (button1.Content.ToString() == "X")
                {
                    playerX++;
                    Player1Score.Text = playerX.ToString();
                }
                else
                {
                    playerO++;
                    Player2Score.Text = playerO.ToString();
                }
                return true;
            }
            return false;
        }

        private bool CheckColumn(int col)
        {
            Button button1 = (Button)GameBoard.Children[col];
            Button button2 = (Button)GameBoard.Children[col + 3];
            Button button3 = (Button)GameBoard.Children[col + 6];
            if (button1.Content == button2.Content && button2.Content == button3.Content && button1.Content != null)
            {
                MessageBox.Show("A győztes: " + button1.Content);
                if (button1.Content.ToString() == "X")
                {
                    playerX++;
                    Player1Score.Text = playerX.ToString();
                }
                else
                {
                    playerO++;
                    Player2Score.Text = playerO.ToString();
                }
                return true;
            }
            return false;
        }

        private bool CheckRow(int row)
        {
            Button button1 = (Button)GameBoard.Children[row * 3];
            Button button2 = (Button)GameBoard.Children[row * 3 + 1];
            Button button3 = (Button)GameBoard.Children[row * 3 + 2];
            if (button1.Content == button2.Content && button2.Content == button3.Content && button1.Content != null)
            {
                MessageBox.Show("Winner is: " + button1.Content);
                if (button1.Content.ToString() == "X")
                {
                    playerX++;
                    Player1Score.Text = playerX.ToString();
                }
                else
                {
                    playerO++;
                    Player2Score.Text = playerO.ToString();
                }
                return true;
            }
            return false;
        }

        private void UjJatek(object sender, RoutedEventArgs e)
        {
            GenerateBoard();
        }

    }
}