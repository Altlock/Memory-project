﻿using System.Windows;
using System.Windows.Controls;
using System.Collections;
namespace Memory
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     Variable containing x by y of card hashtables
        /// </summary>
        public static Hashtable[,] GameBoard;
        /// <summary>
        ///     Variable containing UI grid containing images.
        /// </summary>
        public static Grid CardGrid;
        /// <summary>
        ///     Start of the program, makes calls to functions to:
        ///     make a new shuffled matrix * 6 and print them out 1 by 1.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            GameBoard = Matrix.Make(Card.Shuffled(Constant.AllUnique));
            Matrix.TraceBoard(GameBoard);
            var rootGrid = new Grid {Name = "RootGrid"};

            //var hoofdmenu = new Grid();
            //rootGrid.Children.Add(hoofdmenu);
            GeneratePlayGrid(rootGrid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootGrid">Grid to put playgrid into</param>
        private void GeneratePlayGrid(Grid rootGrid)
        {
            var playingInfo = new Grid { Name = "PlayingInfo" };

            CardGrid = GameLogic.FillCardGrid(GameBoard, GameLogic.GenerateCardGrid());
            rootGrid.Children.Add(CardGrid);
            GameLogic.AddColumns(rootGrid, 1);
            rootGrid.Children.Add(playingInfo);
            Grid.SetColumn(playingInfo, 1);
            MWindow.Content = rootGrid;
        }
    }
}