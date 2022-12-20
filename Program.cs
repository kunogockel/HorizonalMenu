using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonalMenu
{
    // Demo program for HorizonalMenu
    class Program
    {
        // Program enty point
        static void Main(string[] args)
        {
            // clear screen
            Console.Clear();
            // create the menu
            HorizonalMenu menu = new HorizonalMenu("Apple", "Banana", "Orange", "Pineapple", "Pear", "Plum");
            // run the menu and get the selected option
            int selection = menu.run();
            // display result
            Console.WriteLine();
            if (selection >= 0)
                Console.WriteLine("Selected option is: #{0} {1}", selection, menu.m_options[selection]);
            else
                Console.WriteLine("Selection aborted");
        }
    }

    // Implements an horizonal menu
    // 2022-12-19 KG Created
    public class HorizonalMenu
    {
        // row where the menu is displayed on the screen
        public int m_top = 0;
        // currently selected option
        public int m_selectedIndex = 0;
        // list of options
        public string[] m_options = null;
        
        // Constructor
        public HorizonalMenu()
        {
        }

        // Constructor which accepts a list of options
        public HorizonalMenu(params string[] options)
        {
            m_options = options;
        }

        // Shows the list of options, marking the currently selected one
        public void displayOptions()
        {
            Console.SetCursorPosition(0, m_top);
            for (int i = 0; i < m_options.Length; i++)
            {
                if (i == m_selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", m_options[i]);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("{0} ", m_options[i]);
                }
            }
        }

        // Runs the menu
        public int run()
        {
            displayOptions();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    return m_selectedIndex;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    m_selectedIndex++;
                    if (m_selectedIndex >= m_options.Length)
                        m_selectedIndex = 0;
                    displayOptions();
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    m_selectedIndex--;
                    if (m_selectedIndex < 0)
                        m_selectedIndex = m_options.Length - 1;
                    displayOptions();
                }
            }
        }
    }
}
