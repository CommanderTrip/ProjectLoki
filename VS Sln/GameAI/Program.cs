using GameAI.FiniteStateMachine.WestWorldWithLadyAndMessage;
using System;

namespace GameAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Miner bob = new Miner(0);
            Wife elsa = new Wife(1);

            for (int i = 0; i < 30; i++)
            {
                bob.update();
                elsa.update();

                System.Threading.Thread.Sleep(1200);
            }
        }
    }
}
