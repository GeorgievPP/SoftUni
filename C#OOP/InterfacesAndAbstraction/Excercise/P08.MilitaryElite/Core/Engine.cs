using System;
using System.Collections.Generic;
using System.Linq;

using P08.MilitaryElite.Models;
using P08.MilitaryElite.Contracts;
using P08.MilitaryElite.Exceptions;
using P08.MilitaryElite.IO.Contracts;

namespace P08.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        private Engine() 
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string command;
            while((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if(soldierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }

                else if(soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach(var pid in cmdArgs.Skip(5))
                    {
                        ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));

                        general.AddPrivate(privateToAdd);
                    }

                    soldier = general;
                }

                else if(soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairArgs = cmdArgs.Skip(6).ToArray();

                        for (int i = 0; i < repairArgs.Length; i+=2)
                        {
                            string partName = repairArgs[i];
                            int hoursWorked = int.Parse(repairArgs[i + 1]);

                            IRepair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;
                    }
                    catch(InvalidCorpsException ice)
                    {
                        continue;
                    }

                }

                else if(soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionArgs = cmdArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i+=2)
                        {
                            try
                            {
                                string missionCodeName = missionArgs[i];
                                string missionState = missionArgs[i + 1];

                                IMission mission = new Mission(missionCodeName, missionState);

                                commando.AddMission(mission);
                            }
                            catch (InvalidMissionStateException)
                            {
                                continue;
                            }

                        }

                        soldier = commando;
                    }
                    catch(InvalidCorpsException ice)
                    {
                        continue;
                        throw;
                    }
                }

                else if(soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if(soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

            }

            foreach(var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }

        }

    }
}
