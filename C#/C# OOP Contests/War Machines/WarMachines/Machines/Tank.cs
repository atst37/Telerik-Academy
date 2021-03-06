﻿namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    // IMachine is implemented already, so Ctrl + . to ITank =>
    public class Tank : Machine, ITank, IMachine
    {
        private const int InitialHealthPoints = 100;
        private const int AttackPointsChange = 40;
        private const int DefensePointsChange = 30;


        // must be created constructor, because there is not upper
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
            // TODO: start defence mode
        }

        // no validation
        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
            {
                this.AttackPoints -= AttackPointsChange;
                this.DefensePoints += DefensePointsChange;
            }
            else
            {
                this.AttackPoints += AttackPointsChange;
                this.DefensePoints -= DefensePointsChange;
            }
        }

        public override string ToString()
        {
            var baseString = base.ToString();

            var result = new StringBuilder();

            result.Append(baseString);
            result.Append(string.Format(
                " *Defense: {0}", 
                    this.DefenseMode 
                    ? "ON" 
                    : "OFF"));

            return result.ToString();
        }
    }
}
