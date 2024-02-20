// // using System;
// // using System.Threading;

// // class Program
// // {
// //     static void Main(string[] args)
// //     {
// //         Console.WriteLine("Stick Figure Doing the Griddy Dance");
// //         Console.WriteLine("Press any key to start dancing...");

// //         // Console.ReadKey();
// //         // int time = 100;
// //         // while (time == 100)
// //         {
// //         Console.Clear();

// //         // Initial position
// //         Console.WriteLine("    \\O/");
// //         Console.WriteLine("     |");
// //         Console.WriteLine("    / \\");

// //         Thread.Sleep(1000);

// //         // First move
// //         Console.Clear();
// //         Console.WriteLine("     O");
// //         Console.WriteLine("    /|\\");
// //         Console.WriteLine("    / \\");

// //         Thread.Sleep(500);

// //         // Second move
// //         Console.Clear();
// //         Console.WriteLine("    \\O/");
// //         Console.WriteLine("     |");
// //         Console.WriteLine("    / \\");

// //         Thread.Sleep(500);

// //         // Third move
// //         Console.Clear();
// //         Console.WriteLine("     O");
// //         Console.WriteLine("    / \\");
// //         Console.WriteLine("    / \\");

// //         Thread.Sleep(500);

// //         // Fourth move
// //         Console.Clear();
// //         Console.WriteLine("    \\O/");
// //         Console.WriteLine("     |");
// //         Console.WriteLine("    / \\");

// //         Thread.Sleep(500);

// //         // Fifth move
// //         Console.Clear();
// //         Console.WriteLine("     O");
// //         Console.WriteLine("    /|\\");
// //         Console.WriteLine("    / \\");

// //         Console.WriteLine("Press any key to exit...");
// //         // Console.ReadKey();
// //         }
// //     }
// // }
// using System;
// using System.Threading;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Stick Figure Doing the Griddy Dance");
//         Console.WriteLine("Press any key to start dancing...");
//         // Console.ReadKey();
//         Console.Clear();

//         for (int i = 0; i < 4; i++)
//         {
//             DrawLegs(i);
//             Thread.Sleep(300);
//             Console.Clear();
//         }

//         Console.WriteLine("Press any key to exit...");
//         // Console.ReadKey();
//     }

//     static void DrawLegs(int iteration)
//     {
//         string[] legs = {
//             "     O",
//             "    /|\\",
//             "   / | \\",
//             "    / \\",
//             "   /   \\",
//             "  /     \\",
//             "  /     \\",
//             " /       \\",
//             " /       \\",
//             " /       \\",
//             " /       \\",
//             " /       \\"
//         };

//         string[] arms = {
//             "    \\O/",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "    /O\\",
//             "     |",
//             "     |"
//         };

//         string[] torso = {
//             "    /_\\",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "     |",
//             "    /_\\",
//             "     |",
//             "     |"
//         };

//         Console.WriteLine(arms[iteration]);
//         Console.WriteLine(torso[iteration]);
//         Console.WriteLine(legs[iteration]);
//         Console.WriteLine(legs[11 - iteration]);
//     }
// }
