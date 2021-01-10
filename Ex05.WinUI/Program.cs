using System;
using System.Collections.Generic;
using System.Text;
using B19_Ex02;

// $G$ SFN-012 (+6) Bonus: Graphics

// $G$ SFN-013 (-5) You should not show empty form on the 1st screen

namespace Ex05.WinUI
{
    public class Program
    {
            public static void Main()
            {
                OtheloGame gameForm = new OtheloGame();
                gameForm.ShowDialog();
            }
    }
}