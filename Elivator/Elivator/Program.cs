using System;

namespace Elivator

{
    class Program
    {
        static void Main(string[] args)
        {
            elevator obj = new elevator();
            obj.getInputFromUser();
        }
    }

    public class elevator
    {
        int iChoice;
        int iCurrentPossition = 0;

        public void getInputFromUser()
        {
            Console.WriteLine("Please enter the floor number to visit.");
            if (int.TryParse(Console.ReadLine(), out iChoice))
            {
                elevatorAction(iChoice);
            }
            else
            {
                Console.WriteLine("Please enter valid input (int value)");
                getInputFromUser();
            }
        }
        private void moveUp(int idestinationFloor)
        {
            for (int i = iCurrentPossition; i <= idestinationFloor; i++)
            {
                Console.WriteLine("you are on " + i + " floor");
                if (i == idestinationFloor)
                {

                    Console.WriteLine("have a good day. bye bye");
                    iCurrentPossition = idestinationFloor;
                    idestinationFloor = 0;
                    break;
                }
            }
            getInputFromUser();


        }
        private void moveDown(int idestinationFloor)
        {
            for (int i = iCurrentPossition; i >= idestinationFloor; i--)
            {
                Console.WriteLine("you are on " + i + " floor");
                if (i == idestinationFloor)
                {

                    Console.WriteLine("have a good day. bye bye");
                    iCurrentPossition = idestinationFloor;
                    idestinationFloor = 0;
                    break;
                }
            }
            getInputFromUser();
        }
        private void elevatorAction(int iDestinationFloor)
        {
            if (iDestinationFloor > iCurrentPossition)
            {
                moveUp(iDestinationFloor);
            }
            else if (iDestinationFloor < iCurrentPossition)
            {
                moveDown(iDestinationFloor);
            }
        }


    }

}