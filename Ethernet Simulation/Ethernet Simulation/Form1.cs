using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ethernet_Simulation
{
    public partial class mainForm : Form
    {
        //Global Variables for simulator
        //Boolean VALID_INPUTS = false;
        Boolean[] VALID_INPUTS = new Boolean[5];
        static Random RANDOM_X = new Random();
        static Random RANDOM_C = new Random();
        static Random RANDOM_S = new Random();
        static Random RANDOM_COMPUTER = new Random();
        String output_string;
        int MAX_WAIT_TIME = 0;
        int TOTAL_SLOTS_USED = 0;

        public mainForm()
        {
            InitializeComponent();
        }

        //Method for when "Begin Simulation" is clicked
        private void runBtn_Click(object sender, EventArgs e)
        {
            int n=0, t=0, k=0, s=0, x = 0;

            //Check if the input values are numeric. If so, set respective variable to value
            VALID_INPUTS[0] = is_number(nBox.Text);
            if (VALID_INPUTS[0])
            {
                n = Convert.ToInt32(nBox.Text);
            }
            VALID_INPUTS[1] = is_number(tBox.Text);
            if (VALID_INPUTS[1])
            {
                t = Convert.ToInt32(tBox.Text);
            }
            VALID_INPUTS[2] = is_number(kBox.Text);
            if (VALID_INPUTS[2])
            {
                k = Convert.ToInt32(kBox.Text);
            }
            VALID_INPUTS[3] = is_number(sBox.Text);
            if (VALID_INPUTS[3])
            {
                s = Convert.ToInt32(sBox.Text);
            }
            VALID_INPUTS[4] = is_number(xBox.Text);
            if (VALID_INPUTS[4])
            {
                x = Convert.ToInt32(xBox.Text);
            }

            //Check if all variables have valid inputs
            if (Array.IndexOf(VALID_INPUTS, false) == -1)
            {
                //All variables are valid. Begin simulation
                outputBox.Text = "PLEASE WAIT ...";
                begin_simulation(n, t, k, s, x);
            }
            else
            {
                //At least one of the inputs are not valid
                outputBox.Text = "ERROR WITH INPUT VALUES. PLEASE CHECK VALUES AND RERUN SIMULATION\n";
            }
        }

        //Supporting method for runBtn_Click
        //Checks if input string is a number
        //Returns Boolean
        private bool is_number(string input)
        {
            //Try and convert the input
            try
            {
                int n = Convert.ToInt32(input);
                //Input is a number
                return true;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
                //return false;
            }
            //Input is not a number
            return false;
            
        }

        //Runs the simulation from beginning to end using the given values from the user
        //Also displays the output of the simulation
        private void begin_simulation(int n, int t, int k, int s, int x)
        {
            
            //Initial local variables.
            int S = s;
            MAX_WAIT_TIME = 0; //Stores the maximum waiting time for a computer
            TOTAL_SLOTS_USED = 0; //Stores the number of time slots a computer accesses the channel
            int[] random_computers = new int[x+5]; //Int array that stores the computers that are randomly selected [Array is as big as X input]           
            int[] back_off_timer = new int[n+1]; //Int array that stores the wait time off all computers [Array is as big as N+1 input]
            for(int time=0; time < back_off_timer.Length ; time++) 
            {
                back_off_timer[time] = -1; //Set the wait times for all computers to -1
            }
            Boolean slotted_machine = false;
            int slotted_machine_number = 0;

            //Outputs text about simulation
            string newsection = "========================================" + Environment.NewLine;
            outputBox.Text = "NEW SIMULATION: " + DateTime.Now.ToString() + Environment.NewLine;
            outputBox.Text += newsection;
            outputBox.Text += "The simulation will now run with the following inputs;" + Environment.NewLine;
            outputBox.Text += "N = " + n + "\tT = " + t + Environment.NewLine;
            outputBox.Text += "K = " + k + "\tS = " + s + Environment.NewLine;
            outputBox.Text += "X = " + x + Environment.NewLine;
            outputBox.Text += newsection;

            //Time slot loop that runs from 0 to T
            for (int ti = 0; ti < t; ti++)
            {
                output_string += "TIME SLOT #" + (ti+1);

                slotted_machine_number = Array.IndexOf(back_off_timer, 0);
                if (slotted_machine_number > -1)
                {
                    slotted_machine = true;
                    output_string += "   (TIME SLOT ALSO ASSIGNED TO " + slotted_machine_number + ")"; 
                }

                output_string += Environment.NewLine;

                //Randomly select number of computers that will attempt to access channel [Random value from 0 to X]
                int xi = RANDOM_X.Next(x);

                //Randomly selected number of computers is 0
                if(xi == 0)
                {
                    if (slotted_machine)
                    {
                        output_string += "ACCESS GRANTED TO COMPUTER " + slotted_machine_number + Environment.NewLine;
                        //Increase "total slots used" by 1
                        TOTAL_SLOTS_USED++;
                    }
                    else
                    {
                        output_string += "THERE ARE NO COMPUTERS ATTEMPTING TO ACCESS THE CHANNEL" + Environment.NewLine;
                    }
                }

                //Randomly selected nmber of computers is 1
                else if(xi == 1)
                {
                    //Randomly select next computer number
                    int next_computer = get_next_computer(n);

                    if (slotted_machine)
                    {
                        //outputBox.Text += "COMPUTER " + next_computer + " IS ALSO ATTEMPTING TO ACCESS THE CHANNEL" + Environment.NewLine;
                        random_computers[0] = next_computer;
                        random_computers[1] = slotted_machine_number;
                        int selected_computer = RANDOM_COMPUTER.Next(2);
                        output_string += "ACCESS GRANTED TO COMPUTER " + next_computer + Environment.NewLine;
                        TOTAL_SLOTS_USED++;

                        if(selected_computer == 0)
                        {
                            //Selected computer was random computer
                            back_off_timer[random_computers[0]] = next_time_slot(S);
                            output_string += "   COMPUTER " + random_computers[0] + " BACKED OFF AND NOW HAS A WAIT TIME OF " + back_off_timer[random_computers[0]] + Environment.NewLine;
                        }
                        else
                        {
                            //selected computer was slotted machine
                            back_off_timer[random_computers[1]] = next_time_slot(S);
                            output_string += "   COMPUTER " + random_computers[1] + " BACKED OFF AND NOW HAS A WAIT TIME OF " + back_off_timer[random_computers[1]] + Environment.NewLine;
                        }
                        if (S < t)
                        {
                            S = S * 2;
                        }

                    }
                    else
                    {
                        //Output message and computer that gained access to channel
                        //outputBox.Text += "THERE IS 1 COMPUTER ATTEMPTING TO ACCESS THE CHANNEL" + Environment.NewLine;
                        output_string += "ACCESS GRANTED TO COMPUTER " + next_computer + Environment.NewLine;
                        //Increase "total slots used" by 1
                        TOTAL_SLOTS_USED++;
                    }
                }
                else
                {
                    //Output message
                    //outputBox.Text += "THERE ARE " + xi + " COMPUTERS ATTEMPTING TO ACCESS THE CHANNEL" + Environment.NewLine;
                    //outputBox.Text += "THOSE COMPUTERS ARE: ";

                    //Loop to select random computers
                    for (int ci = 0; ci < xi; ci++)
                    {
                        //Randomly select next computer number
                        int next_computer = get_next_computer(n);
                        //Make sure randomly selected computer is not already in random_computers arrray
                        while ((Array.IndexOf(random_computers, next_computer)>-1) && (back_off_timer[next_computer] < 1))
                        {
                            //Keep randomly choosing a computer number number until it is not in random_computers array
                            next_computer = get_next_computer(n);
                        }
                        //Add randomly selected computer to random_computers array
                        random_computers[ci] = next_computer;
                        //outputBox.Text += next_computer + "   ";
                    }
                    if(slotted_machine)
                    {
                        random_computers[xi] = slotted_machine_number;
                    }
                    //outputBox.Text += Environment.NewLine;

                    
                    //Randomly select a computer from array of computers attempting to access channel
                    int selected_computer = 0;
                    if (slotted_machine)
                    {
                        selected_computer = RANDOM_COMPUTER.Next(xi+1);
                    }
                    else
                    {
                        selected_computer = RANDOM_COMPUTER.Next(xi);
                    }

                    output_string += "ACCESS GRANTED TO COMPUTER " + random_computers[selected_computer] + Environment.NewLine;

                    //Increase "total slots used" by 1
                    TOTAL_SLOTS_USED++;

                    //Loop to update wait_time for computers that did not access channel.
                    foreach (int comp in random_computers)
                    {
                        //Make sure to only update wait_time for computers that were selected AND did not access the channel
                        if (comp != random_computers[selected_computer] && comp > 0)
                        {
                            //Update wait_time for current computer
                            back_off_timer[comp] = next_time_slot(S);
                            if (back_off_timer[comp] > MAX_WAIT_TIME)
                            {
                                //If the current calculated wait_time is greater than current MAX_WAIT_TIME, set MAX_WAIT_TIME to calculated wait_time
                                MAX_WAIT_TIME = back_off_timer[comp];
                            }
                            //Report updated wait_time for computers
                            output_string += "   COMPUTER " + comp + " BACKED OFF AND NOW HAS A WAIT TIME OF " + back_off_timer[comp] + Environment.NewLine;
                            
                        }
                    }
                    //outputBox.Text += S;
                    //Reset the random_computers array
                    reset_random_computers(random_computers);
                    //Double S due to collision. 
                    if (S < t)
                    {
                        S = S * 2;
                    }
                }

                //Limit output to the first 100 time slots.
                if (t < 100)
                {
                    outputBox.Text += output_string + newsection;
                }
                output_string = "";
                reduce_wait_timer(back_off_timer);
                slotted_machine = false;
                //End of Loop
            }//End of Simulation

            //Display the results of "total bytes sent" and "maximum node wait time"
            outputBox.Text += "RESULTS" + Environment.NewLine + Environment.NewLine;
            int bytes = (k * TOTAL_SLOTS_USED);
            outputBox.Text += "TOTAL BYTES SENT: " + bytes;
            //Converting to Kilobytes
            if(bytes > 1024)
            {
                double kilo = bytes / 1024.00;
                outputBox.Text += " / " + kilo.ToString("#.##") +" KB"; 
            }
            //Converting to Megabytes
            if (bytes > 1048576)
            {
                double mega = bytes / 1048576.00;
                outputBox.Text += " / " + mega.ToString("#.##") +" MB";
            }
            //Converting to Gigabytes
            if (bytes > 1073741824)
            {
                double giga = bytes / 1073741824.00;
                outputBox.Text += " / " + giga.ToString("#.##") +" GB";
            }
            outputBox.Text += " [" + k + " BYTES x " + TOTAL_SLOTS_USED + " SLOTS USED]" + Environment.NewLine;

            outputBox.Text += "MAX WAITING TIME FOR NODE: " + MAX_WAIT_TIME + Environment.NewLine;
        }

        //Reduces the amount of time slots that a computer should wait
        //Called after every time slot
        private void reduce_wait_timer(int[] back_off_timer)
        {
            for(int c = 1; c<back_off_timer.Length; c++)
            {
                if(back_off_timer[c] > -1)
                {
                    back_off_timer[c]--;
                }
            }
        }

        //Resets the random_computers array so that it can be used again
        private void reset_random_computers(int[] random_computers)
        {
            for (int c = 0; c < random_computers.Length; c++)
            {
                random_computers[c] = 0;
            }
        }

        //Supporting method that randomly selects a computer number from 1 to N 
        private int get_next_computer(int n)
        {
            return RANDOM_C.Next(1,n+1);
        }

        //Picks a random amount of time slots to wait before a computer can attempt to communicate again.
        private int next_time_slot(int s)
        {
            int future_time_slot = RANDOM_S.Next(1,s+1);
            return future_time_slot;
        }

        //Clears output textbox
        private void clearBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = "";
            //TODO: Clear variable textboxes
        }
    }
}
