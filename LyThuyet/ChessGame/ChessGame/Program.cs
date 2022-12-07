using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGame
{
    class Logic
    {
        public bool isValid()
        {
            return true;
        }
    }
    class Game : Form
    {
        public Button[,] table = new Button[8, 8];
        public int[,] map = new int[8, 8]
        {
            {15, 14, 13, 12, 11, 13, 14, 15},
            {16, 16, 16, 16, 16, 16, 16, 16},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {26, 26, 26, 26, 26, 26, 26, 26},
            {25, 24, 23, 22, 21, 23, 24, 25},
        };
        public Button prevButton;
        public bool isMoving = false;
        public int side = 1;
        public void createTable()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = new Button();
                    table[i, j].Size = new Size(60, 60);
                    table[i, j].Location = new Point(j * 60, i * 60);
                    table[i, j].BackColor = Color.White;
                    if ((i + j) % 2 == 0)
                    {
                        table[i, j].BackColor = Color.White;
                    }
                    else table[i, j].BackColor = Color.RosyBrown;
                    this.Controls.Add(table[i, j]);
                }
            }
        }
        public void reloadColor()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        table[i, j].BackColor = Color.White;
                    }
                    else table[i, j].BackColor = Color.RosyBrown;
                }
            }
        }
        public void loadTable()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    string piece = "";
                    int chessMan = map[i, j] % 10;
                    switch (chessMan)
                    {
                        case 1:
                            piece += "king_";
                            break;
                        case 2:
                            piece += "queen_";
                            break;
                        case 3:
                            piece += "bishop_";
                            break;
                        case 4:
                            piece += "knight_";
                            break;
                        case 5:
                            piece += "rook_";
                            break;
                        case 6:
                            piece += "pawn_";
                            break;
                        default:
                            //MessageBox.Show("Buggggg1  " + "i = " + i + "    j = " + j + chessMan);
                            break;
                    }
                    int side = map[i, j] / 10;
                    switch (side)
                    {
                        case 1:
                            piece += "white";
                            break;
                        case 2:
                            piece += "black";
                            break;
                        default:
                            //MessageBox.Show("Buggggg2  " + "i = " + i + "    j = " + j + side);
                            break;
                    }
                    if (side != 0 && chessMan != 0)
                    {
                        table[i, j].BackgroundImage = Image.FromFile("images\\" + piece + ".png");
                        table[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                        
                    }
                    table[i, j].Click += new EventHandler(OnFigurePress);   
                }
            }
        }
        public void OnFigurePress(Object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Button pressedButton = sender as Button;
            int press_side = map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60]/10;
            Console.WriteLine("current press_side: " + side);
            Console.WriteLine("press_side chosen: " + press_side);
            Console.WriteLine("chosen: " + pressedButton.Location.Y / 60 + pressedButton.Location.X / 60);
            if ((isMoving == false && (press_side == 0 || press_side != side)) || (isMoving == true && press_side == side)) 
            {
                Console.WriteLine("Wrong!");
                isMoving = false;
                reloadColor();
                return;
            }
            if (isMoving == false)
            {
                if (map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60] != 0)
                {
                    isMoving = true;
                    pressedButton.BackColor = Color.Yellow;
                    prevButton = pressedButton;
                }
            }
            else if (isMoving == true)
            {
                if (map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60] != 0)
                {
                    if (false) //Check xem co an duoc khong, truong hop nay an duoc (false de pass qua truong hop nay)
                    {
                        
                    }
                    else
                    {
                        prevButton = null;
                    }
                }
                else if (map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60] == 0)
                {
                    if (true) //Check xem nuoc di hop le khong, truong hop nay hop le
                    {
                        // Doi id chessman
                        int idChessman = map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60];
                        Console.WriteLine("idChessman: " + idChessman);
                        Console.WriteLine("Pressed: " + map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60]);
                        Console.WriteLine("Prev: " + map[prevButton.Location.Y / 60, prevButton.Location.X / 60]);
                        map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60] = map[prevButton.Location.Y / 60, prevButton.Location.X / 60];
                        map[prevButton.Location.Y / 60, prevButton.Location.X / 60] = idChessman;

                        Console.WriteLine("Pressed: " + map[pressedButton.Location.Y / 60, pressedButton.Location.X / 60]);
                        Console.WriteLine("Prev: " + map[prevButton.Location.Y / 60, prevButton.Location.X / 60]);

                        pressedButton.BackgroundImage = prevButton.BackgroundImage;
                        pressedButton.BackgroundImageLayout = prevButton.BackgroundImageLayout;
                        prevButton.BackgroundImage = null;
                        prevButton.BackColor = Color.White;
                        isMoving = false;
                        side = (side == 1) ? 2 : 1;
                    }
                    else
                    {

                    }
                }
                reloadColor();
                
            }
        }
        public Game()
        {
            this.Size = new Size(540, 540);
            createTable();
            loadTable();
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Game game = new Game();
            Application.Run(game);
        }
    }
}
