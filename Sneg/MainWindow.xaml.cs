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
using System.Windows.Threading;

namespace Sneg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int playerScore;
        public double gameSpeed;
        public int foodTicks;
        public int previousFood = 5;
        public bool shitGotReal = false;
        public bool shitIsAlreadyReal = false;
        
        public BitmapImage[] snekImages;
        
        
        
        DispatcherTimer timer;
        List<Image> foodForSnek;

        public enum DIRECTION{
            LEFT,
            RIGHT,
            DOWN,
            UP };

        DIRECTION currentDirection;

        Ellipse snekPlayer;
        public List<Ellipse> snekParts;

        Grid gridForCanvas;
        RowDefinition[] rows;
        ColumnDefinition[] columns;

        public MainWindow()
        {
            InitializeComponent();
            snekImages = new BitmapImage[7];
            snekImages[0] = new BitmapImage(new Uri("Assets\\SneakySnek3.png", UriKind.Relative));
            snekImages[1] = new BitmapImage(new Uri("Assets\\ThinkingSnek2.png", UriKind.Relative));
            snekImages[2] = new BitmapImage(new Uri("Assets\\StaringSnek2.png", UriKind.Relative));
            snekImages[3] = new BitmapImage(new Uri("Assets\\ExtremeSnek2.png", UriKind.Relative));
            snekImages[4] = new BitmapImage(new Uri("Assets\\ConfusedSnek2.png", UriKind.Relative));
            snekImages[5] = new BitmapImage(new Uri("Assets\\Plain-Crepe-Sprite-Small.png", UriKind.Relative));
            snekImages[6] = new BitmapImage(new Uri("Assets\\strawberry-Small.png", UriKind.Relative));
            snekParts = new List<Ellipse>();
            foodForSnek = new List<Image>();
            imageOfSnek.Source = snekImages[0];
            //whenShitGetsRealElement.Visibility = Visibility.Collapsed;
            
            snekParts.Add(snekPlayer);

            try
            {

                
                startMusic();
                
                currentDirection = DIRECTION.RIGHT;

                playerScore = 0;
                

                gridForCanvas = setGrid();
                gameCanvas.Children.Add(gridForCanvas);
                snekPlayer = new Ellipse()
                {
                    Width = 20,
                    Height = 20,
                    Fill = new SolidColorBrush(Colors.Green),
                };

                gridForCanvas.Children.Add(snekPlayer);

                gameSpeed = 350;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
                timer.Tick += Timer_Tick;

                timer.Start();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                moveSnekParts(currentDirection);
                foodTicks += 1;
                if(foodTicks == 5)
                {
                    generateFood();
                    foodTicks = 0;
                }                

                scoreKeeper(playerScore);
                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        private Grid setGrid()
        {
            Grid toReturn = new Grid();
            rows = new RowDefinition[35];
            columns = new ColumnDefinition[50];

            for(int y = 0; y < rows.Length; y++)
            {
                rows[y] = new RowDefinition()
                {
                    MaxHeight = 20,
                    MinHeight = 20,
                };               
            }

            for(int x= 0; x < columns.Length; x++)
            {
                columns[x] = new ColumnDefinition()
                {
                    MaxWidth = 20,
                    MinWidth = 20,
                };
            }

            foreach(ColumnDefinition column in columns)
            {
                toReturn.ColumnDefinitions.Add(column);
            }

            foreach(RowDefinition row in rows)
            {
                toReturn.RowDefinitions.Add(row);
            }

            return toReturn;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                case Key.A:
                    currentDirection = DIRECTION.LEFT;
                    break;
                case Key.Right:
                case Key.D:
                    currentDirection = DIRECTION.RIGHT;
                    break;
                case Key.Up:
                case Key.W:
                    currentDirection = DIRECTION.UP;
                    break;
                case Key.Down:
                case Key.S:
                    currentDirection = DIRECTION.DOWN;
                    break;
            }
        }

        public void scoreKeeper(int score)
        {
            scoreLabel.Content = playerScore.ToString();
            if (score > 80)
            {
                imageOfSnek.Source = snekImages[3];
                shitGotReal = true;

                whenShitGetsReal(shitGotReal);


            }
            else if (score > 50)
            {
                imageOfSnek.Source = snekImages[4];
            }
            else if(score > 20)
            {
                imageOfSnek.Source = snekImages[2];
            }
            else if (score > 10)
            {
                imageOfSnek.Source = snekImages[1];
            }
        }

        public void addSnekPart()
        {
            try
            {
                    snekParts.Add(new Ellipse()
                    {
                        Width = 18,
                        Height = 18,
                        Fill = new SolidColorBrush(Colors.DarkRed),
                    });
                    snekParts[snekParts.Count - 1].Visibility = Visibility.Hidden;
                    gridForCanvas.Children.Add(snekParts[snekParts.Count - 1]);
                    
                    int lastPartRowNumber = (int)snekParts[snekParts.Count - 1].GetValue(Grid.RowProperty);
                    int lastPartColumnNumber = (int)snekParts[snekParts.Count - 1].GetValue(Grid.ColumnProperty);

                    snekParts[snekParts.Count - 1].SetValue(Grid.RowProperty, lastPartRowNumber);
                    snekParts[snekParts.Count - 1].SetValue(Grid.ColumnProperty, lastPartColumnNumber);
                    snekParts[snekParts.Count - 1].Visibility = Visibility.Visible;


            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
                gameSpeed = gameSpeed - 25;
                if(gameSpeed < 50)
            {
                gameSpeed = 50;
            }
            timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            
        }

        public void moveSnekParts(DIRECTION direction)
        {
            int currentColumn = (int)this.snekPlayer.GetValue(Grid.ColumnProperty);
            int currentRow = (int)this.snekPlayer.GetValue(Grid.RowProperty);

            checkForCollision(currentRow, currentColumn);
            

            switch (direction)
            {
                case DIRECTION.DOWN:
                    if (currentRow + 1 > gridForCanvas.RowDefinitions.Count)
                    {
                        this.snekPlayer.SetValue(Grid.RowProperty, 0);
                        currentRow = 0;
                        moveTail(currentRow, currentColumn);

                    }
                    else
                    {
                        this.snekPlayer.SetValue(Grid.RowProperty, currentRow + 1);
                        moveTail(currentRow, currentColumn);
                    }
                    break;
                case DIRECTION.UP:
                    if (currentRow - 1 < 0)
                    {
                        this.snekPlayer.SetValue(Grid.RowProperty, gridForCanvas.RowDefinitions.Count - 1);
                        moveTail(currentRow, currentColumn);
                    }
                    else
                    {
                        this.snekPlayer.SetValue(Grid.RowProperty, currentRow - 1);
                        moveTail(currentRow, currentColumn);
                    }
                    break;

                case DIRECTION.LEFT:
                    if (currentColumn - 1 < 0)
                    {
                        this.snekPlayer.SetValue(Grid.ColumnProperty, gridForCanvas.ColumnDefinitions.Count - 1);
                        currentColumn = gridForCanvas.ColumnDefinitions.Count - 1;
                        moveTail(currentRow, currentColumn);
                    }
                    else
                    {
                        this.snekPlayer.SetValue(Grid.ColumnProperty, currentColumn - 1);
                        moveTail(currentRow, currentColumn);
                    }
                    break;
                case DIRECTION.RIGHT:
                    if (currentColumn + 1 > gridForCanvas.ColumnDefinitions.Count)
                    {
                        this.snekPlayer.SetValue(Grid.ColumnProperty, 0);
                        currentColumn = 0;
                        moveTail(currentRow, currentColumn);
                    }
                    else
                    {
                        this.snekPlayer.SetValue(Grid.ColumnProperty, currentColumn + 1);
                        moveTail(currentRow, currentColumn);
                    }
                    break;
            }
            if (eatFood(snekPlayer))
            {
                playerScore += 1;
                addSnekPart();
            }

        }

        public void moveTail(int row,int column)
        {
            int startingRow = row,startingColumn = column;
            int tempRow = 0, tempColumn = 0;


            for(int i = 1; i < snekParts.Count; i++)
            {

                tempRow = (int)snekParts[i].GetValue(Grid.RowProperty);
                tempColumn = (int)snekParts[i].GetValue(Grid.ColumnProperty);
                snekParts[i].SetValue(Grid.RowProperty, startingRow);
                snekParts[i].SetValue(Grid.ColumnProperty, startingColumn);
                startingRow = tempRow;
                startingColumn = tempColumn;
            }
        }

        public void generateFood()
        {
            int rowAmount = this.gridForCanvas.RowDefinitions.Count-1;
            int columnAmount = this.gridForCanvas.ColumnDefinitions.Count-1;

            try
            {
                int foodRow = randomNumbers(2, rowAmount);
                int foodColumn = randomNumbers(2, columnAmount);
                if(foodColumn != (int)snekPlayer.GetValue(Grid.ColumnProperty) ||
                    foodRow != (int)snekPlayer.GetValue(Grid.ColumnProperty))
                {
                    if(foodForSnek.Count < 10)
                    {
                        
                        if(previousFood == 6)
                        {
                            foodForSnek.Add(new Image()
                            {
                                Source = snekImages[previousFood],
                            });
                            previousFood = 5;
                        }
                        else
                        {
                            foodForSnek.Add(new Image()
                            {
                                Source = snekImages[previousFood],
                            });
                            previousFood = 6;
                        }


                        


                        gridForCanvas.Children.Add(foodForSnek[foodForSnek.Count - 1]);
                        foodForSnek[foodForSnek.Count - 1].SetValue(Grid.RowProperty, foodRow);
                        foodForSnek[foodForSnek.Count - 1].SetValue(Grid.ColumnProperty, foodColumn);
                    }

                }
                else
                {
                    generateFood();
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private bool eatFood(Ellipse snekHead)
        {
            bool didItEat = false;
            int snekHeadRow = (int)snekHead.GetValue(Grid.RowProperty);
            int snekHeadColumn = (int)snekHead.GetValue(Grid.ColumnProperty);


            try
            {
                foreach(Image food in foodForSnek)
                {
                    int foodRow = (int)food.GetValue(Grid.RowProperty);
                    int foodColumn = (int)food.GetValue(Grid.ColumnProperty);
                    if (snekHeadRow == foodRow && snekHeadColumn == foodColumn)
                    {
                        didItEat = true;
                        int index = foodForSnek.IndexOf(food);
                        gridForCanvas.Children.Remove(foodForSnek[index]);
                        foodForSnek.Remove(food);
                        break;
                    }
                }

            }catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            return didItEat;
        }

        public int randomNumbers(int min, int max)
        {
            Random rng = new Random();
            return rng.Next(min, max);
        }

        public void checkForCollision(int headRow,int headColumn)
        {
            try
            {
                if (snekParts.Count > 1)
                {
                    for(int i = 1; i < snekParts.Count; i++)
                    {
                        int partRow = (int)snekParts[i].GetValue(Grid.RowProperty);
                        int partColumn = (int)snekParts[i].GetValue(Grid.ColumnProperty);

                        if (headRow == partRow && headColumn == partColumn)
                        {
                            gameOver(playerScore);
                        }
                    }
                }
            }catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public void startMusic()
        {
            try
            {                
                //gameTimeTunes.LoadedBehavior = MediaState.Manual;
                //gameTimeTunes.UnloadedBehavior = MediaState.Manual;
                gameTimeTunes.Volume = 1.0;
                gameTimeTunes.Play();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }

        }

        public void whenShitGetsReal(bool forReal)
        {

            if (forReal && !shitIsAlreadyReal)
            {
                gameTimeTunes.Source = new Uri("Assets\\GottaLetItOut.mp3", UriKind.Relative);

                whenShitGetsRealElement.Source = new Uri("Assets\\ExtremeFireSnek2.mp4", UriKind.Relative);

                whenShitGetsRealElement.Visibility = Visibility.Visible;
                whenShitGetsRealElement.Play();

            }
            shitIsAlreadyReal = true;


        }

        private void gameTimeTunes_MediaEnded(object sender, RoutedEventArgs e)
        {
            gameTimeTunes.Position = TimeSpan.FromSeconds(0);
            gameTimeTunes.Play();
        }

        private void whenShitGetsRealElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            whenShitGetsRealElement.Position = TimeSpan.FromMilliseconds(0);
            whenShitGetsRealElement.Play();
        }

        private void gameOver(int resultingScore)
        {
            try
            {                 
                    new Screens.PostGameScreen(resultingScore).Show();
                    timer.Stop();
                    this.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
