using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EZInput;
namespace Game
{
    static class Global
    {
      public static  int limit = 100000;
       public static int px = 0;
       public static int py = 0;
        const int playerheigth = 4;
        const int playerwidth = 6;
       public static int ex1 = 6;
       public static int ey1 = 3;
       public static int ex2 = 120;
       public static int ey2 = 4;
       public static int ex3 = 24;
       public static int ey3 = 7;
      public static  int score = 0;

      public static  int bx = 0;
      public static  int by = 0;
      public static  int health = 50;
      public static  int fireLimit = 0;

        public static int[] e1bulletx = new int[limit];
      public static  int[] e1bullety = new int[limit];
      public static  bool[] activeEbullet = new bool[limit];
      public static  int e1index = 0;
      public static  int e1count = 0;

      public static  char[][] arr = new char[][]
        {
            "#####################################################################################################################################################".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#p                                                                                                                                                  #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#                                                                                                                                                   #".ToCharArray(),
            "#####################################################################################################################################################".ToCharArray()
        };


      public static  char[,] player = new char[,]
{
    { ' ', ' ','u',' ', ' ' },
    { '.', ':', ':', ':', '.' },
    { ':', ':', ':', ':', ':' },
    { ':', ':', ':', ':', ':' }
};
    }

    internal class Program
    {
       
        

        static void Main(string[] args)
        {
            
            interface1(); 
            logo();
            
            
            printBoard();
            printPlayer();
            string direction1 = "rigth";
            string direction2 = "rigth";
            string direction3 = "rigth";

            while (true)
            {
                string result = menu();
                if (result == "1")
                {
                    instructions();
                   

                }
                else if (result == "2")
                {
                    while (true)
                    {

                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                         
                            movePlayerLeft();
                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                        
                            moveplayerRigth();
                        }
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                          
                            movePlayerUp();
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                         
                            movePlayerDown();
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                         
                            createBullet();
                        }

                        checkDirection(ref direction1);
                        moveEnemey1(direction1);
                        checkDirection2(ref direction2);
                        movee2(direction2);
                        checkDirection3(ref direction3); 
                        movee3(direction3);
                        moveBullet();

                        moveE1bullet();
                        healthDecrease();
                        Console.SetCursorPosition(150, 10);
                        Console.Write("Score(30 to win): " + Global.score);
                        Console.SetCursorPosition(150, 11);
                        Console.Write("Health: " +Global. health );
                       
                        if (Global.health == 0) 
                        {
                            youLose();
                         
                            break;
                        }
                        else if (Global.score == 30)
                        {
                            youWin();
                            
                            break;
                        }
                    }
                }
                else if (result == "3")
                {
                    break;
                }

                else
                {
                    Console.Write("Invalid option.");
                }
            }
        }
    static    void healthDecrease()
        { 

            int i = Global.py + 2;
            int j = Global.px;
            if (getCharAtxy(i, j) == 'u')
            {
                if (getCharAtxy(i - 2, j) == '*' || getCharAtxy(i - 2, j + 1) == '*' || getCharAtxy(i - 2, j + 2) == '*' || getCharAtxy(i - 2, j + 3) == '*' || getCharAtxy(i - 1, j) == '*' || getCharAtxy(i + 1, j) == '*' || getCharAtxy(i + 2, j) == '*' || getCharAtxy(i + 3, j) == '*' || getCharAtxy(i + 3, j + 1) == '*' || getCharAtxy(i + 3, j + 2) == '*' || getCharAtxy(i + 3, j + 3) == '*')
                    Global.health--;
            } 
        }

        private static char getCharAtxy(int v, int j)
        {
            throw new NotImplementedException();
        }

        static   void printBoard()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (Global.arr[i][j] == 'p')
                    {
                       Global. px = i;
                       Global. py = j;
                        printPlayer();
                    }
                    else
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(Global.arr[i][j]);
                    }
                }
            }
        }

      static  void printPlayer()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(Global.py + j, Global.px + i);
                    Console.Write(Global.player[i,j]);
                    if (Global.player[i,j] == '*')
                    {
                        Global. score = Global.score + 1;
                    }
                }
            }
        }
     static   void erasePlayer()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(Global.py, Global.px + i);
                    Console.Write( "      ");
                }
            }
        }

      static  void createBullet()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (Global.arr[i][j] == 'p' && Global.arr[i - 1][j] == ' ')
                    {
                        Console.SetCursorPosition(j + 2, i - 1);
                        Console.Write(".");

                       Global. bx = j + 2;
                      Global.  by = i - 1;
                    }
                }
            }
        }

      static  void moveBullet()
        {

            if (Global.bx != 0 &&Global. by != 0)
            {
                if (getCharAtxy(Global.bx,Global. by - 1) != '#')
                {
                    Console.SetCursorPosition(Global.bx,Global. by);
                    Console.Write(" ");
                    if (getCharAtxy(Global.bx,Global. by) != '#')
                    {
                        Console.SetCursorPosition(Global.bx,Global. by - 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(Global.bx,Global. by - 1);
                       Global. by --;
                        Console.Write(".");

                        if (getCharAtxy(Global.bx, Global.by - 1) == '_' || getCharAtxy(Global.bx, Global.by - 1) == '|' || getCharAtxy(Global.bx, Global.by - 1) == ',' || getCharAtxy(Global.bx, Global.by - 1) == '(' || getCharAtxy(Global.bx, Global.by - 1) == ')' || getCharAtxy(Global. bx,Global. by - 1) == '+' || getCharAtxy(Global.bx, Global.by - 1) == '\\' || getCharAtxy(Global.bx,Global. by - 1) == '/')
                        {
                            Console.SetCursorPosition(Global.bx, Global.by);
                            Console.Write(" ");
                           Global. score =Global. score + 1;
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition(Global.bx, Global.by);
                    Console.Write(" ");
                }
            }
        }
      static  void moveBullet1()
        {
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 130; j++)
                {
                    if (getCharAtxy(j, i) == '*')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                        Console.SetCursorPosition(j, i + 1);
                        Console.Write("*");
                        break;
                    }
                }
            }
        }

      static  void movePlayerLeft()
        {
            if (Global.arr[Global.px][Global.py - 1] != '#')
            {
                erasePlayer();
               Global. arr[Global.px][Global.py] = ' ';
               Global. py --;
               Global. arr[Global.px][Global.py] = 'p';
                printPlayer();
                if (Global.arr[Global.px][Global.py - 1] == '*')
                {
                    Global.score = Global.score + 1;
                }
            }
        }
       static void scoreIncrement()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Global.player[i,j] == '*')
                    {
                        Global.score =Global. score + 1;
                    }
                }
            }
        }

      static  void moveplayerRigth()
        {
            if (Global.arr[Global.px][Global.py + 7] != '#')
            {
                erasePlayer();
                Global.arr[Global.px][Global.py] = ' ';
               Global. py++;
                Global.arr[Global.px][Global.py] = 'p';
                printPlayer();
                if (Global.arr[Global.px][Global.py + 1] == '*')
                {
                    Global.score++;
                }
            }
        }

       static void movePlayerUp()
        {
            if (Global.arr[Global.px - 1][Global.py] != '#')
            {
                erasePlayer();
                Global.arr[Global.px][Global.py] = ' ';
              Global.  px--;
               Global. arr[Global.px][Global.py] = 'p';
                printPlayer();
                if (Global.arr[Global.px - 1][Global.py] == '*')
                {
                    Global.score++;
                }
            }
        }

      static  void movePlayerDown()
        {
            if (Global.arr[Global.px + 4][Global.py] != '#')
            {
                erasePlayer();
                Global.arr[Global.px][Global.py] = ' ';
               Global. px++;
               Global. arr[Global.px][Global.py] = 'p';
                printPlayer();
                if (Global.arr[Global.px + 1][Global.py] == '*')
                {
                   Global. score ++;
                }
            }
        }
       
       
      
     static   void printe1()
        {
            Console.SetCursorPosition(Global.ex1,Global. ey1);
            Console.WriteLine("'__' " );
            Console.SetCursorPosition(Global.ex1, Global.ey1 + 1);
            Console.WriteLine("(++) " );
            Console.SetCursorPosition(Global.ex1,Global. ey1 + 2);
            Console.WriteLine("/||\\" );
            Console.SetCursorPosition(Global.ex1,Global. ey1 + 3);
            Console.WriteLine("_||_ " );
        }

      static  void erasee1()
        {
            Console.SetCursorPosition(Global.ex1, Global.ey1);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex1, Global.ey1 + 1);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex1, Global.ey1 + 2);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex1, Global.ey1 + 3);
            Console.WriteLine("     " );
        }
      static  void checkDirection(ref string direction)
        {
            if (direction == "rigth" && Global.ex1 >= 142)
            {
                direction = "Left";
            }
            if (direction == "Left" &&Global. ex1 <= 2)
            {
                direction = "rigth";
            }
        }

      static  void enemy1Bullet()
        {
            int exb1 =Global. ex1 + 1;
            int eyb1 =Global. ey1 + 2;
            Console.SetCursorPosition(exb1, eyb1);
          
            Console.Write("*");

           Global. e1bulletx[Global.e1index] = exb1;
           Global. e1bullety[Global.e1index] = eyb1;
          Global.  activeEbullet[Global.e1index] = true;
          Global.  e1index++;
          Global.  e1count++;
        }
       static void moveE1bullet() 
        { 
            for (int i = 0; i < Global.e1count; i++)
            {
                if (Global.activeEbullet[i] == true)
                {
                    if (getCharAtxy(Global.e1bulletx[i], Global.e1bullety[i] + 1) == ' ')
                    {
                        Console.SetCursorPosition(Global.e1bulletx[i], Global.e1bullety[i]);
                        Console.Write(" ");
                       Global. e1bullety[i]++;
                        Console.SetCursorPosition(Global.e1bulletx[i],Global. e1bullety[i]);
                        
                        Console.Write("*");
                    }
                    else if (getCharAtxy(Global.e1bulletx[i],Global. e1bullety[i + 1]) != ' ')
                    {
                        Console.SetCursorPosition(Global.e1bulletx[i],Global. e1bullety[i]);
                        Console.Write(" ");
                    }
                    else if (getCharAtxy(0, 0) == 'u')
                    {
                       Global. health--;
                    }
                }
            }
            if (Global.fireLimit > 10)
            {
                enemy1Bullet();
                Global.fireLimit = 0;
            }
            else
            {
               Global. fireLimit++;
            }
        }


      static  void moveEnemey1(string direction)
        {
            if (direction == "rigth")
            {
                erasee1();

               Global. ex1 ++;

                printe1();
            }
            else if (direction == "Left")
            {
                erasee1();
               Global. ex1--;

                printe1();
            }
        }

       static void printe2()
        {
            Console.SetCursorPosition(Global.ex2,Global. ey2);
            Console.WriteLine("'__' " );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 1);
            Console.WriteLine("(++) " );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 2);
            Console.WriteLine("/||\\" );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 3);
            Console.WriteLine("_||_ " );
        }

       static void checkDirection2(ref string direction)

        {
            if (direction == "rigth" &&Global. ey2 >= 35)
            {
                direction = "left";
            }
            if (direction == "left" &&Global. ey2 <= 2)
            {
                direction = "rigth";
            }
        }
        // oid health1()
        //
        //  if(getCharAtxy(px-1,py)=='*'||getCharAtxy(px-1,py)=='*'||getCharAtxy(px,py+1)=='*'||getCharAtxy(px,py-1)=='*')
        //  {
        //      health = health - 1;
        //      cout<<px<<py;
        //  }
        //

       static void erasee2()
        {
            Console.SetCursorPosition(Global.ex2,Global. ey2);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 1);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 2);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex2,Global. ey2 + 3);
            Console.WriteLine("     " );
        }

       static void movee2(string direction)
        {
            if (direction == "rigth")
            {
                erasee2();

              Global.  ey2 ++;

                printe2();
            }
            if (direction == "left")

            {
                erasee2();
               Global. ey2 --;
                printe2();
            }
        }
       static void checkDirection3(ref string direction)
        {
            if (direction == "rigth" &&Global. ex3 >= 50 &&Global. ey3 >= 30)
            {
                direction = "left";
            }
            if (direction == "left" &&Global. ex3 <= 20 &&Global. ey3 <= 20)
            {
                direction = "rigth";
            }
        }

      static  void printe3()
        {
            Console.SetCursorPosition(Global.ex3,Global. ey3);
            Console.WriteLine("'__' " );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 1);
            Console.WriteLine("(++) " );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 2);
            Console.WriteLine("/||\\" );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 3);
            Console.WriteLine("_||_ " );
        }

      static  void erasee3()
        {
            Console.SetCursorPosition(Global.ex3,Global. ey3);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 1);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 2);
            Console.WriteLine("     " );
            Console.SetCursorPosition(Global.ex3,Global. ey3 + 3);
            Console.WriteLine("     " );
        }

       static void movee3(string direction)
        {
            if (direction == "rigth")
            {
                erasee3();

               Global. ex3 ++;
                Global.ey3++;

                printe3();
            }
            if (direction == "left")
            {
                erasee3();
               Global. ex3 --;
               Global. ey3 --;
                printe3();
            }
        }
        
       static void interface1()
        {
            Console.SetCursorPosition(40, 20);
            Console.WriteLine(" _   _                     _ _   _       _   _                         " );
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("| | | | ___ _ __ _ __ ___ (_) |_( )___  | | | | __ ___   _____   ___   " );
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("| |_| |/ _ \\ '__| '_ ` _ \\| | __|// __| | |_| |/ _` \\ \\ / / _ \\ / __|  " );
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("|  _  |  __/ |  | | | | | | | |_  \\__ \\ |  _  | (_| |\\ V / (_) | (__   " );
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("|_| |_|\\___|_|  |_| |_| |_|_|\\__| |___/ |_| |_|\\__,_| \\_/ \\___/ \\___|  " );
        }
      static  void logo()
        {

            Console.WriteLine("                                                                         mdv                   " );
            Console.WriteLine("                                                                         vii                   " );
            Console.WriteLine("                                                                          vdr                  " );
            Console.WriteLine("                                                                           rdv                 " );
            Console.WriteLine("                                                                            ii                 " );
            Console.WriteLine("                                                                            v0m                " );
            Console.WriteLine("                                                                             r0v               " );
            Console.WriteLine("                                                                              di               " );
            Console.WriteLine("                                                      vv                       0m              " );
            Console.WriteLine("                                                   vmi  mdv                    rdv             " );
            Console.WriteLine("                                                 dm        vdm                 v0m0            " );
            Console.WriteLine("                                             m00iiiiiidiiiiidd060v           rirmm0            " );
            Console.WriteLine("                                             vmiiidm   r0m0miimv         rim1 rivrim           " );
            Console.WriteLine("                                                   d   r0rd     vvvvridiimr v6v   div          " );
            Console.WriteLine("                                                   rr r0r r6W6dr r0v   vmiv  vi    0m          " );
            Console.WriteLine("                       v0immmmimmmr                 dr0mmirviid  v0r  m0r     vi   rdv         " );
            Console.WriteLine("                       vd0di0dmr1v    mi66mrrriii00mv  vii0m  6rvi  v0d      rmi    ii         " );
            Console.WriteLine("                         dmm6i rmi       rdm      div   v6R6v    irm6  m00iv        v0r        " );
            Console.WriteLine("                               ird         0m      idr     dr    rimmv               m0        " );
            Console.WriteLine("                               0rd   dir    idm     viv   r01dr   d                  vmd       " );
            Console.WriteLine("                               0dr    rd0v   virm           6  rd d                   mmr      " );
            Console.WriteLine("                                vvd0dd0dm  v           6v 0rrv                    id          " );
            Console.WriteLine("                                          riv0i      vr0rmdvd                     vdr         " );
            Console.WriteLine("                                            vii60v     rddmvi                                 " );
            Console.WriteLine("                                               d m6W6ddd1driv                                 " );
            Console.WriteLine("                                             drr6drv     vr0                                  " );
            Console.WriteLine("                                          riv mvviimiddmv      rmmm                           " );
            Console.WriteLine("                                       riv    d  riiv iv        r6v  iir                      " );
            Console.WriteLine("                                     0v      vi  irr   d      vdd       d                     " );
            Console.WriteLine("                                  m0idmrimrdmv   riv   iv     dd        i                     " );
            Console.WriteLine("                               ir  drrvi          0r   d    vivr       mr                     " );
            Console.WriteLine("                             mm v  viiv iv        0    0r   iviv      rr                      " );
            Console.WriteLine("                           dr irmdv0mrrr dv      dd    6rmvi iv      rm                       " );
            Console.WriteLine("                        vir   d   ridrimi rr    rri    0m   rr      vm                        " );
            Console.WriteLine("                      r00v mm vm      v0ddrvi    i     iv066dmrv    rv                        " );
            Console.WriteLine("                   vir  vi    v    vvidv  d6i0v  vvvridiivivrr  vddmir                        " );
            Console.WriteLine("                 dr   i0drdv   vdmv          vvvv     vidr   vdv                              " );
            Console.WriteLine("              viv  i0dv     mmr                       r00000iimmmiv                           " );
            Console.WriteLine("             vd    im                                                                         " );
            Console.WriteLine("r000000000000000600r" );
        }
       static void youLose()
        {
            Console.WriteLine("__   __               _                   " );
            Console.WriteLine("\\ \\ / /__  _   _     | |    ___  ___  ___ " );
            Console.WriteLine(" \\ V / _ \\| | | |    | |   / _ \\/ __|/ _ \\  " );
            Console.WriteLine("  | | (_) | |_| |    | |__| (_) \\__ \\  __/" );
            Console.WriteLine("  |_|\\___/ \\__,_|    |_____\\___/|___/\\___|" );
        }

       static void youWin()
        {
            Console.WriteLine("__   __              __        __           " );
            Console.WriteLine("\\ \\ / /__  _   _     \\ \\      / /__  _ __   " );
            Console.WriteLine(" \\ V / _ \\| | | |     \\ \\ /\\ / / _ \\| '_ \\  " );
            Console.WriteLine("  | | (_) | |_| |      \\ V  V / (_) | | | | " );
            Console.WriteLine("  |_|\\___/ \\__,_|       \\_/\\_/ \\___/|_| |_| " );
        }
       static string menu()
        {
            string op;
            Console.SetCursorPosition(30, 40);
            Console.Write("1. See the instructions: " );
            Console.SetCursorPosition(30, 41);
            Console.Write("2. Play the Game: " );
            Console.SetCursorPosition(30, 42);
            Console.Write("3. Exit: " );
             op=Console.ReadLine();
            return op;
        }
       static void instructions()
        {
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("Enter space to create bullet." );
            Console.SetCursorPosition(30, 21);
            Console.WriteLine("Enter left arrow key to move left." );
            Console.SetCursorPosition(30, 22);
            Console.WriteLine("Enter rigth arrow key to move rigth." );
            Console.SetCursorPosition(30, 23);
            Console.WriteLine("Enter up arrow key to move up." );
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("Enter down arrow key to move down." );
            Console.SetCursorPosition(30, 25);
            Console.WriteLine("You have to score 30 points to win the game." );
        }
    }
}
